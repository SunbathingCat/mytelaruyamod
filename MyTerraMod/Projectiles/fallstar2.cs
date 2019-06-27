using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Projectiles
{
    public class fallstar2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("fallenstar V2");
        }

        public override void SetDefaults()
        {
            // projectile.CloneDefaults(ProjectileID.FallingStar);
            // aiType = ProjectileID.FallingStar;
            projectile.width = 20;
            // 弹幕判定体积的高度
            projectile.height = 20;
            projectile.scale = 0.8f;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.light = 1.5f;
            projectile.timeLeft = 120;
        }
        /*public override void AI()
        {
            if (projectile.timeLeft < 177)
            {
                // 火焰粒子特效
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height
                    , DustID.Fire, 0f, 0f, 100, default(Color), 3f);
                // 粒子特效不受重力
                dust.noGravity = true;
            }
        }*/
        /*public override bool PreKill(int timeLeft)
        {
            projectile.type = ProjectileID.FallingStar;
            return true;
        }*/

        /*public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 5; i++)
            {
                int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.Starfury, (int)(projectile.damage * .5f), 0, projectile.owner);
                Main.projectile[a].aiStyle = 1;
                Main.projectile[a].tileCollide = true;
            }
            return true;
        }*/
    }
}
