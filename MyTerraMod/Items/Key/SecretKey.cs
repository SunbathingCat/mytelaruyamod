using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Key
{
    public class SecretKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("万能密钥");
            Tooltip.SetDefault("打开所有箱子");
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
            item.value = 0;
            item.createTile = mod.TileType("ADChest");
        }

        /*public override void AddRecipes()
        {
            // VineRope  Hay
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 2);
            // recipe.AddIngredient(ItemID.Hay, 2);
            // recipe.AddTile(TileID.WorkBenches);
            recipe.AddTile(TileID.Chairs);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
        // 管理员不花钱
        /*public override bool CanUseItem(Player player)
        {
            if (Main.LocalPlayer.CanBuyItem(10, -1))
            {

                return base.CanUseItem(player);
            }
            else
            {
                return false;
            }  
        }
        public override bool UseItem(Player player)
        {
            player.BuyItem(10, -1);
            return base.UseItem(player);
        }*/


        // 不可用
        /* int timerClone = 0;
         public override bool UseItem(Player player)
         {
             timerClone++;
             if (timerClone == 60)
             {
                 timerClone = 0;
                 player.inventory[0].stack -= 10;
             }
             return base.UseItem(player);
         }*/
    }
}
