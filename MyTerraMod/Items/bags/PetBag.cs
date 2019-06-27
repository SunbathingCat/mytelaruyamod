using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.bags
{
    public class PetBag : ModItem
    {
        int[] goods = new int[] { ItemID.Carrot, ItemID.AmberMosquito, ItemID.Fish, ItemID.BoneRattle, ItemID.BoneKey, ItemID.ParrotCracker, ItemID.Seaweed, ItemID.StrangeGlowingMushroom, ItemID.ToySled, ItemID.EatersBone, ItemID.Nectar, ItemID.LizardEgg, ItemID.Seedling, ItemID.TikiTotem, ItemID.EyeSpring, ItemID.MagicalPumpkinSeed, ItemID.UnluckyYarn, ItemID.CursedSapling, ItemID.SpiderEgg, ItemID.DogWhistle,ItemID.BabyGrinchMischiefWhistle,ItemID.TartarSauce,ItemID.ZephyrFish,ItemID.CompanionCube,ItemID.DD2PetGato,ItemID.DD2PetDragon,ItemID.ShadowOrb,ItemID.CrimsonHeart,ItemID.MagicLantern,ItemID.FairyBell,ItemID.DD2PetGhost,ItemID.WispinaBottle,ItemID.SuspiciousLookingTentacle };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pet Bag");
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
                    player.QuickSpawnItem(mod.ItemType("PetBag"));
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
