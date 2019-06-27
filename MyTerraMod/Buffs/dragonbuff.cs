using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MyTerraMod.Utilss;

namespace MyTerraMod.Buffs
{
    public class dragonbuff : ModBuff
    {
        public override void SetDefaults()
        {
            // 设置buff名字和描述
            DisplayName.SetDefault("免疫");
            Description.SetDefault("免疫一切debuff，生命值大于一半时生效");


            // 这个属性决定buff在游戏退出再进来后会不会仍然持续，true就是不会，false就是会
            Main.buffNoSave[Type] = false;

            // 用来判定这个buff算不算一个debuff，如果设置为true会得到TR里对于debuff的限制，比如无法取消
            Main.debuff[Type] = false;

            // 当然你也可以用这个属性让这个buff即使不是debuff也不能取消，设为false就是不能取消了
            this.canBeCleared = false;

            // 决定这个buff是不是照明宠物的buff，以后讲宠物和召唤物的时候会用到的，现在先设为false
            Main.lightPet[Type] = false;

            // 决定这个buff会不会显示持续时间，false就是会显示，true就是不会显示，一般宠物buff都不会显示
            Main.buffNoTimeDisplay[Type] = true;

            // 决定这个buff在专家模式会不会持续时间加长，false是不会，true是会
            this.longerExpertDebuff = false;

            // 如果这个属性为true，pvp的时候就可以给对手加上这个debuff/buff
            Main.pvpBuff[Type] = false;

            // 决定这个buff是不是一个装饰性宠物，用来判定的，比如消除buff的时候不会消除它
            Main.vanityPet[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Venom] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Blackout] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.WitheredArmor] = true;
            player.buffImmune[BuffID.WitheredWeapon] = true;
            player.buffImmune[BuffID.Horrified] = true;///////////
            player.buffImmune[BuffID.TheTongue] = true;//////////
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.Ichor] = true;
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Wet] = true;
            player.buffImmune[BuffID.Webbed] = true;
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.Electrified] = true;
            player.buffImmune[BuffID.Suffocation] = true;
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.Stinky] = true;
            player.buffImmune[BuffID.WindPushed] = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.Oiled] = true;
            player.buffImmune[BuffID.ShadowFlame] = true;
            player.buffImmune[BuffID.BetsysCurse] = true;
            player.buffImmune[BuffID.Daybreak] = true;
            Lighting.AddLight(player.position, 0.0f, 1.0f, 0.0f);
            // 冒绿光
            for (int i = 0; i < 3; i++)
            {
                Dust dust = Dust.NewDustDirect(player.position, player.width, 10,
                    MyDustId.GreenFx, 0, -2f, 100, Color.White, 1.15f);
                dust.noGravity = true;
            }
        }
    }
}
