using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class tulong : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("tulong");
            Tooltip.SetDefault("...");
        }
        public override void SetDefaults()
        {
            item.damage = 50;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 1.2f;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (!target.boss)
            {
                player.ApplyDamageToNPC(target, target.lifeMax/10, 5, player.direction, false);
            }
            else
            {
                player.ApplyDamageToNPC(target, 1000, 5, player.direction, false);
            }
        }
        public override void HoldItem(Player player)
        {
            /*
            item.damage = 50 + (int)((1 - (float)(player.statLife) / (float)player.statLifeMax) * 100);
            item.scale = 1 + (1 - (float)(player.statLife) / (float)player.statLifeMax);
            */
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
