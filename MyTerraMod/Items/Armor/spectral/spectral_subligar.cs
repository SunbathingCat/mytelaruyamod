using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MyTerraMod.Items.Armor.spectral
{
    [AutoloadEquip(EquipType.Legs)]
    public class spectral_subligar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("鬼魂护腿");
            Tooltip.SetDefault("最大魔法值增加30" +
                "\n魔法伤害增加10%" +
                "\n移动速度增加10%" +
                "\n魔法值消耗降低15%");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = 2;
            item.defense = 15;
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
            player.moveSpeed += 0.1f;
            player.magicDamage += 0.1f;
            player.statManaMax2 += 30;
            player.manaCost -= 0.15f;
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

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumLeggings, 1);
            recipe.AddIngredient(ItemID.OrichalcumLeggings, 1);
            recipe.AddIngredient(ItemID.TitaniumLeggings, 1);
            recipe.AddIngredient(ItemID.HallowedGreaves, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
