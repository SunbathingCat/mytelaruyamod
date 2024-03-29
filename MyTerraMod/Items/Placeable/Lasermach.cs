﻿using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Placeable
{
    public class Lasermach :ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a modded 激光钻机.");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 500;
            item.createTile = mod.TileType("lasermachtile");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
