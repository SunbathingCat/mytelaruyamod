using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MyTerraMod.Utilss;
using System.Linq;


namespace MyTerraMod.Projectiles
{
    public class laser1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("猩红电流");
        }
        public override void SetDefaults()
        {
            /*
            projectile.width = 4;
            projectile.height = 4;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.timeLeft = 900;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 100;
            */
            projectile.CloneDefaults(ProjectileID.MagnetSphereBolt);
            projectile.magic = false;
            projectile.width = 4;
            projectile.height = 4;
            projectile.scale = 0.25f;
        }
        /*public override void AI()
        {
            // 发出红光
            Lighting.AddLight(projectile.position, 1.0f, 1.0f, 0.0f);

            // 线性粒子效果
            for (int i = 0; i < 3; i++)
            {
                Dust d = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, MyDustId.YellowTorch, 0, 0, 100, Color.LightYellow, 1f);
                d.position = projectile.Center - projectile.velocity * i / 3f;
                d.velocity *= 0.01f;
                d.noGravity = true;
                d.scale = (float)Main.rand.Next(45, 55) * 0.014f;
            }
        }*/

    }
}
