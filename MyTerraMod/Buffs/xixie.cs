using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MyTerraMod.Utilss;

namespace MyTerraMod.Buffs
{
    public class xixie : ModBuff
    {
        int lifereal = 500;
        int counts = 0;
        public override void SetDefaults()
        {
            // 设置buff名字和描述
            DisplayName.SetDefault("魔头");
            Description.SetDefault("不停的杀戮才能维持生命值");

            Main.buffNoSave[Type] = false;
 
            Main.debuff[Type] = true;

            this.canBeCleared = false;

            Main.lightPet[Type] = false;

            Main.buffNoTimeDisplay[Type] = false;
            this.longerExpertDebuff = false;

            Main.pvpBuff[Type] = true;

            Main.vanityPet[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            counts++;
            if (counts==1)
            {
                lifereal = player.statLifeMax;
            }
            if (counts==60)
            {
                counts = 2;
            }
            // 冒绿光
            player.lifeRegen = 0;
            // player.lifeRegen -= 2;
            player.noKnockback = true;
            player.moveSpeed += 0.5f;
            for (int i = 0; i < 3; i++)
            {
                Dust dust = Dust.NewDustDirect(player.position, player.width, 10,
                    MyDustId.GreenFx, 0, -2f, 100, Color.White, 1.15f);
                dust.noGravity = true;
            }

            // buff消失前的一瞬间，绿光爆发233333
            // player.buffTime[buffIndex] 就是这个buff的剩余时间
            if (player.buffTime[buffIndex] < 1)
            {
                player.statLifeMax = lifereal;
                for (int i = 0; i < 100; i++)
                {
                    Dust.NewDustDirect(player.position, player.width, 10,
                        MyDustId.GreenFx, 0, -2f, 100, Color.White, 1.5f);
                }
            }
        }
    }
}
