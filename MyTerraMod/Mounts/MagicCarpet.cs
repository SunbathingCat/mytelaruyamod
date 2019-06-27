using Terraria.ID;
using Terraria.ModLoader;


namespace MyTerraMod.Mounts
{
    public class MagicCarpet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("飞毯");
            Tooltip.SetDefault("召唤一个汽车坐骑\n需要凝胶作为燃料才能维持");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = 30000;
            item.rare = 2;
            item.UseSound = SoundID.Item79;
            item.noMelee = true;
            item.mountType = mod.MountType("MCarpet");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar, 10);
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.AddIngredient(ItemID.SilverBar, 2);
            recipe.AddIngredient(ItemID.Glass, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
