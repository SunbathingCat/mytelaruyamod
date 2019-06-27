using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class yitian : ModItem
    {
        int pow = 0;
        NPC mon = new NPC();
        // int ti = 0;
        // int st = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("yitian");
            Tooltip.SetDefault("...");
        }
        public override void SetDefaults()
        {
            item.damage = 50 ;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 1.2f;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            // st = 1;
            if (mon != target)
            {
                mon = target;
                pow = 0;
            }
            else
            {
                pow++;
            }
            if (pow > 0)
            {
                player.ApplyDamageToNPC(target, 25 * pow, 4, player.direction, false);
            }
            // target.life -= 2 * pow;
            // damage = 2 * pow;
            // target.friendly = true;
        }
        public override void HoldItem(Player player)
        {
            Lighting.AddLight(player.position, 1.0f, 1.0f, 1.0f);
            /*if (st!=0)
            {
                ti = 0;
            }
            ti++;
            if (ti > 180)
            {
                st = 0;
            }
            if (ti%60==0&&st==0)
            {
                if(pow>1)
                {
                    pow--;
                }  
            }*/
            player.AddBuff(BuffID.Sunflower,-1);
            // base.HoldItem(player);
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
