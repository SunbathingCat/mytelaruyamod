using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MyTerraMod.Utilss;

namespace MyTerraMod.Items.accessory
{
    public class taijihufu : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("太极护符");
            Tooltip.SetDefault("二分之一概率躲避伤害");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.accessory = true;
            item.defense = 10;
            item.rare = 8;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.expert = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.StoneBlock, 2);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().taiji = true;
        }
    }
}
