using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class DuoMing : ModItem
    {
        int k = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("夺命连环凳");
            Tooltip.SetDefault("简单拼凑出来的武器，随时可能会散架...");
        }

        public override void SetDefaults()
        {
            item.damage = 8;           
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
            item.scale = 1.4f;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            int index=0;
            k++;
            if (k == 5)
            {
                index = Item.NewItem(target.position, ItemID.Wood, 1,true);
                // player.QuickSpawnItem(ItemID.Wood);


            }
            if (k==10)
            {
                index = Item.NewItem(target.position, ItemID.IronOre, 1);
                // player.QuickSpawnItem(ItemID.IronOre);
                k = 0;
            }
            NetMessage.SendData(90, -1, -1, null,index);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenChair, 1);
            recipe.AddIngredient(ItemID.IronOre, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.WoodenChair, 1);
            recipe2.AddIngredient(ItemID.LeadOre, 5);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
