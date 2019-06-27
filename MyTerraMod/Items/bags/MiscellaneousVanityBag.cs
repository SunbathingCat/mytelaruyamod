using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.bags
{
    public class MiscellaneousVanityBag : ModItem
    {
        int[] goods = new int[] { ItemID.ClothierVoodooDoll, ItemID.DiscountCard, ItemID.FlowerBoots, ItemID.GoldRing, ItemID.CordageGuide,ItemID.GuideVoodooDoll,ItemID.JellyfishNecklace,ItemID.LuckyCoin,ItemID.NeptunesShell,ItemID.WinterCape,ItemID.MysteriousCape,ItemID.RedCape,ItemID.CrimsonCloak,ItemID.DiamondRing,ItemID.AngelHalo,ItemID.GingerBeard,ItemID.MusicBoxNight,ItemID.MusicBoxOcean,ItemID.MusicBoxJungle,ItemID.MusicBoxHell};

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("MiscellaneousVanity Bag");
            Tooltip.SetDefault("<right> for goodies!");
        }

        public override void SetDefaults()
        {
            item.value = Item.buyPrice(0, 10, 0, 0);
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
                    player.QuickSpawnItem(mod.ItemType("MiscellaneousVanityBag"));
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
