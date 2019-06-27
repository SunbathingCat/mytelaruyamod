using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class TDestroyBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("破坏剑");
            Tooltip.SetDefault("拥有致命一击的一把剑\n右键触发");
        }
        public override void SetDefaults()
        {
            item.damage = 40;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe2.AddIngredient(ItemID.HellstoneBar, 10);
            recipe2.AddIngredient(ItemID.Obsidian, 10);
            recipe2.AddTile(TileID.Hellforge);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.scale = 1.5f;
                item.mana = 50;
                item.useTime = 40;
                item.useAnimation = 40;
                item.damage = 200;
            }
            else
            {
                item.scale = 1.0f;
                item.mana = 0;
                item.useTime = 20;
                item.useAnimation = 20;
                item.damage = 40;
            }
            return base.CanUseItem(player);
        }
    }
}
