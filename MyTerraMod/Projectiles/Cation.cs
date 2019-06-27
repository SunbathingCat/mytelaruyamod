using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MyTerraMod.Projectiles
{
    public class Cation : ModProjectile
    {
        float baseRot = 0.0f;
        int t = 0;
        public override void SetStaticDefaults()
        {
            // The following sets are only applicable to yoyo that use aiStyle 99.
            // YoyosLifeTimeMultiplier is how long in seconds the yoyo will stay out before automatically returning to the player. 
            // Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
            // YoyosMaximumRange is the maximum distance the yoyo sleep away from the player. 
            // Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 400f;
            // YoyosTopSpeed is top speed of the yoyo projectile. 
            // Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
        }
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            // aiStyle 99 is used for all yoyos, and is Extremely suggested, as yoyo are extremely difficult without them
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1.2f;
        }
        public override void AI()
        {
            t++;
            if (t > 10000)
            {
                t = 0;
            }
            NPC target = null;
            // 最大寻敌距离
            float distanceMax = 200f;
            foreach (NPC npc in Main.npc)
            {
                // 如果npc活着且敌对
                if (npc.active && !npc.friendly && npc.type != NPCID.TargetDummy
                    && Collision.CanHit(projectile.Center, 1, 1, npc.position, npc.width, npc.height))
                {
                    // 计算距离
                    float currentDistance = Vector2.Distance(npc.Center, projectile.Center);
                    // 如果npc距离比当前最大距离小
                    if (currentDistance < distanceMax)
                    {
                        // 就把最大距离设置为npc和玩家的距离
                        // 并且暂时选取这个npc为距离最近npc
                        distanceMax = currentDistance;
                        target = npc;
                    }
                }
            }
            baseRot += 0.15f;
            // 如果找到符合条件的npc， 并且符合开火间隔（一秒6次）
            if (target != null && t % 10 < 1)
            {
                Vector2 toTarget = target.Center - projectile.Center;
                toTarget.Normalize();
                toTarget *= 6f;

                toTarget = toTarget.RotatedBy(baseRot);
                for (int i = 0; i < 3; i++)
                {
                    toTarget = toTarget.RotatedBy(MathHelper.Pi / 1.5f);
                    // 我调整了一下发射位置，这样射线看起来更像从磁球中间射出来的
                    Projectile.NewProjectile(projectile.Center + projectile.velocity * 4f,
                                toTarget, mod.ProjectileType("ElectricAction"), projectile.damage, 1f, projectile.owner, target.whoAmI);
                }
            }
        }
        public override void PostAI()
        {
            Lighting.AddLight(projectile.position, 1.0f, 1.0f, 1.0f);
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 16);
                dust.noGravity = true;
                dust.scale = 1.6f;
            }
        }
    }
}
