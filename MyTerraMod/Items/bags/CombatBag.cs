using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.bags
{
    public class CombatBag : ModItem
    {
        int[] goods = new int[] { ItemID.AdhesiveBandage, ItemID.ArmorPolish, ItemID.Bezoar, ItemID.BlackBelt, ItemID.Blindfold, ItemID.MoonCharm, ItemID.CobaltShield, ItemID.CrossNecklace, ItemID.EyeoftheGolem, ItemID.FastClock, ItemID.FeralClaws, ItemID.FleshKnuckles, ItemID.FrozenTurtleShell, ItemID.HandWarmer, ItemID.HoneyComb, ItemID.MagicQuiver, ItemID.MagmaStone, ItemID.Megaphone, ItemID.MoonStone, ItemID.Nazar,ItemID.ObsidianRose,ItemID.PaladinsShield,ItemID.PanicNecklace,ItemID.PocketMirror,ItemID.PutridScent,ItemID.RangerEmblem,ItemID.RifleScope,ItemID.Shackle,ItemID.SharkToothNecklace,ItemID.SorcererEmblem,ItemID.StarCloak,ItemID.SummonerEmblem,ItemID.SunStone,ItemID.TitanGlove,ItemID.TrifoldMap,ItemID.Vitamins,ItemID.WarriorEmblem,ItemID.ApprenticeScarf,ItemID.SquireShield,ItemID.HuntressBuckler,ItemID.MonkBelt,ItemID.NecromanticScroll };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combat Bag");
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
                    player.QuickSpawnItem(mod.ItemType("CombatBag"));
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
