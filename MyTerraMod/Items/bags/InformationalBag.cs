using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.bags
{
    public class InformationalBag : ModItem
    {
        int[] goods = new int[] { ItemID.DepthMeter, ItemID.Compass, ItemID.FishermansGuide, ItemID.WeatherRadio, ItemID.Sextant, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.DPSMeter, ItemID.TallyCounter, ItemID.LifeformAnalyzer, ItemID.Radar};

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Informational Bag");
            Tooltip.SetDefault("<right> for goodies!");
        }

        public override void SetDefaults()
        {
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.maxStack = 999;
            item.width = 20;
            item.height = 20;
            item.rare = 2;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.rand.NextBool())
            {
                player.QuickSpawnItem(goods[Main.rand.Next(goods.Length)]);
            }
            else
            {
                if (Main.rand.NextBool())
                {
                    Main.NewText("谢谢惠顾");
                }
                else
                {
                    player.QuickSpawnItem(mod.ItemType("InformationalBag"));
                    Main.NewText("再来一包");
                }
            }
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ExampleItem"), 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        */
    }
}
