using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.bags
{
    public class StartBag : ModItem
    {
        int[] metri = new int[] { ItemID.Wood, ItemID.SandBlock, ItemID.StoneBlock,ItemID.IceBlock,ItemID.IronOre, ItemID.SilverOre, ItemID.GoldOre, ItemID.Gel };
        int[] tools = new int[] { ItemID.IronHammer,ItemID.IronPickaxe,ItemID.IronAxe, ItemID.IronHammer, ItemID.IronPickaxe, ItemID.IronAxe, ItemID.IronHammer, ItemID.IronPickaxe, ItemID.IronAxe,ItemID.SilverHammer,ItemID.SilverAxe,ItemID.SilverPickaxe, ItemID.SilverHammer, ItemID.SilverAxe, ItemID.SilverPickaxe,ItemID.GoldAxe,ItemID.GoldPickaxe,ItemID.GoldHammer };
        int[] armor = new int[] { ItemID.IronHelmet, ItemID.IronChainmail, ItemID.IronGreaves, ItemID.IronHelmet, ItemID.IronChainmail, ItemID.IronGreaves, ItemID.IronHelmet, ItemID.IronChainmail, ItemID.IronGreaves, ItemID.SilverHelmet, ItemID.SilverChainmail, ItemID.SilverGreaves, ItemID.SilverHelmet, ItemID.SilverChainmail, ItemID.SilverGreaves, ItemID.GoldHelmet, ItemID.GoldChainmail, ItemID.GoldGreaves };
        int[] goods = new int[] { ItemID.GoldBroadsword,ItemID.SilverBroadsword,ItemID.IronBroadsword, ItemID.IronBroadsword , ItemID.IronBroadsword, ItemID.SilverBroadsword };
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("新手礼包");
            Tooltip.SetDefault("<right> for goodies!");
        }

        public override void SetDefaults()
        {
            item.value = Item.buyPrice(0, 5, 0, 0);
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
                player.QuickSpawnItem(tools[Main.rand.Next(goods.Length)]);
            }
            else
            {
                player.QuickSpawnItem(metri[Main.rand.Next(goods.Length)],Main.rand.Next(45,56));
            }
            if (Main.rand.NextBool())
            {
                player.QuickSpawnItem(armor[Main.rand.Next(goods.Length)]);
                if (Main.rand.NextBool())
                {
                    player.QuickSpawnItem(armor[Main.rand.Next(goods.Length)]);
                    if (Main.rand.NextBool())
                    {
                        player.QuickSpawnItem(armor[Main.rand.Next(goods.Length)]);
                    }
                }
            }
            else
            {
                player.QuickSpawnItem(metri[Main.rand.Next(goods.Length)], Main.rand.Next(45, 56));
            }
            if (Main.rand.NextBool())
            {
                player.QuickSpawnItem(goods[Main.rand.Next(goods.Length)]);
            }
            else
            {
                player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(1, 11));
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
