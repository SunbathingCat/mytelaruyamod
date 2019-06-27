using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class DanGong : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("弹弓");
            Tooltip.SetDefault("弹弓");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.thrown = true;
            item.channel = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 5;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 3f;
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
