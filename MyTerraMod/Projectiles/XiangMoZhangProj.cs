﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using MyTerraMod.Utilss;
namespace MyTerraMod.Projectiles
{
    class XiangMoZhangProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true; //so you can't hit enemies through walls
            projectile.melee = true;
        }

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.9f);
            Main.dust[dust].noGravity = true;
        }

        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.OnFire, 180, false);
            }
        }

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.OnFire, 180, false);
            }
        }*/
    }
}
