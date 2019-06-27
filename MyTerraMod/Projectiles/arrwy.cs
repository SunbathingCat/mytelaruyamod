using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MyTerraMod.Projectiles
{
    public class arrwy : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("fallenstar V2");
        }

        public override void SetDefaults()
        {
            // projectile.CloneDefaults(ProjectileID.FallingStar);
            aiType = ProjectileID.TerraBeam;
            projectile.width = 20;
            // 弹幕判定体积的高度
            projectile.height = 20;
            projectile.scale = 1.0f;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.light = 1.5f;
            projectile.timeLeft = 30;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
        }
    }
}
