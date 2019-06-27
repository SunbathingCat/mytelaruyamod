using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MyTerraMod.Items.Armor.dragon
{
    [AutoloadEquip(EquipType.Legs)]
    public class dragon_greaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("神龙护腿");
            Tooltip.SetDefault("移动速度增加12%"
                + "\n近战速度增加2%");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = 2;
            item.defense = 25;
        }
        public override void UpdateEquip(Player player)
        {
            // 如果玩家的速度的值大于一定值，也就是玩家在移动
            /*if (player.velocity.Length() > 0.05f)
            {
                // 就增加全部伤害
                player.meleeDamage += 0.05f;
                player.rangedDamage += 0.05f;
                player.magicDamage += 0.05f;
                player.minionDamage += 0.05f;
                player.thrownDamage += 0.05f;
            }*/
            player.moveSpeed += 0.12f;
            player.meleeSpeed += 0.02f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltLeggings, 1);
            recipe.AddIngredient(ItemID.MythrilGreaves, 1);
            recipe.AddIngredient(ItemID.AdamantiteLeggings, 1);
            recipe.AddIngredient(ItemID.HallowedGreaves, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.PalladiumLeggings, 1);
            recipe2.AddIngredient(ItemID.OrichalcumLeggings, 1);
            recipe2.AddIngredient(ItemID.TitaniumLeggings, 1);
            recipe2.AddIngredient(ItemID.HallowedGreaves, 1);
            recipe2.AddIngredient(ItemID.SoulofFright, 15);
            recipe2.AddIngredient(ItemID.SoulofMight, 15);
            recipe2.AddIngredient(ItemID.SoulofSight, 15);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
