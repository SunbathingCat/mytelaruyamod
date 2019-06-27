using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons.Bullet
{
    public class infenityVenomBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无限恶毒弹");
            Tooltip.SetDefault("爽不爽！");
        }
        public override void SetDefaults()
        {
            item.damage = 14;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 1;
            item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 4.1f;
            item.value = 10;
            item.rare = 2;
            item.shoot = ProjectileID.VenomBullet;   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 5.3f;                  //The speed of the projectile
            item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.EndlessMusketPouch, 1);
            recipe1.AddIngredient(ItemID.VenomBullet, 99);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
