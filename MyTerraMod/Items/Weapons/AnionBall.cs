using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class AnionBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a modded magic weapon.");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.magic = true;
            item.mana = 12;
            item.width = 40;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.channel = true;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("SparklingBall");
            item.shootSpeed = 16f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.StoneBlock, 2);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
