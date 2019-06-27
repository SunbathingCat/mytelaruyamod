using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;


namespace MyTerraMod.Items.Potions
{
    public class InvincibleHuFu : ModItem
    {
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("无敌护符");
            Tooltip.SetDefault("5秒无敌效果");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.rare = 5;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.consumable = true;

            // *新增-决定使用动画出现后，玩家转身会不会影响动画的方向，true就是会，默认为false
            item.useTurn = true;
        }



        public override bool UseItem(Player player)
        {

            // 持续 300 / 60 = 5秒
            player.AddBuff(mod.BuffType("invincible"), 300);
            return true;
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
