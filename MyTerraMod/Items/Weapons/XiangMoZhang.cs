using System;
using MyTerraMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class XiangMoZhang : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("XiangMoZhang");
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            item.melee = true;
            item.width = 20;
            item.height = 12;
            item.useTime = 7;
            item.useAnimation = 25;
            item.channel = true;
            item.noUseGraphic = false;
            item.noMelee = true;
            item.pick = 210;
            item.axe = 20;
            item.tileBoost++;
            item.useStyle = 5;
            item.knockBack = 6;
            item.value = Item.buyPrice(0, 22, 50, 0);
            item.rare = 9;
            item.UseSound = SoundID.Item23;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("XiangMoZhangProj");
            item.shootSpeed = 40f;
        }

        /*public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 2;
        }*/
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
