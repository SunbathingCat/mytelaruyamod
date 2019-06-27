using MyTerraMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class PosionBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("阴离子光球");
            Tooltip.SetDefault("Shoots out an yoyo");

            // These are all related to gamepad controls and don't seem to affect anything else
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 24;
            item.height = 24;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 16f;
            item.knockBack = 2.5f;
            item.damage = 50;
            item.rare = 0;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 1);
            item.shoot = mod.ProjectileType<Posion>();
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
