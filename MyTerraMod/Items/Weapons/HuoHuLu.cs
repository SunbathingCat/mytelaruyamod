using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class HuoHuLu : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("火葫芦");
            Tooltip.SetDefault("喷火的葫芦");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.magic = true;
            item.mana = 2;
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
            item.shoot = ProjectileID.Flames;
            item.shootSpeed = 3f;
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.)
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
