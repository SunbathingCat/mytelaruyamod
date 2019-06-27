using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Key
{
    public class SecretKeyA : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("A型密钥");
            Tooltip.SetDefault("打开A型宝箱，或花费10金放置一个A型宝箱\n第一栏放至少10个金币才能使用");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = false;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = false;
            item.value = 500;
            item.createTile = mod.TileType("AChest");
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SecretKey");
            recipe.SetResult(this,3);
            recipe.AddRecipe();
        }*/
        public override bool CanUseItem(Player player)
        {
            if (Main.LocalPlayer.CanBuyItem(100000,-1))
            {
                player.BuyItem(100000,-1);
                return base.CanUseItem(player);
            }
            else
            {
                return false;
            }
        }
    }
}
