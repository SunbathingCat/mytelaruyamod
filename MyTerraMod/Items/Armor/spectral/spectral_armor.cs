using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Armor.spectral
{
    [AutoloadEquip(EquipType.Body)]
    public class spectral_armor : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("鬼魂长袍");
            Tooltip.SetDefault("魔法伤害增加5%" +
                "\n魔法暴击率增加10%" +
                "\n魔法值消耗降低20%");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 2;
            // 装备的防御值
            item.defense = 20;
        }
        public override void UpdateEquip(Player player)
        {
            // 免疫灼伤debuff
            // player.buffImmune[BuffID.OnFire] = true;
            // 增加生命上限50
            // player.statLifeMax2 += 50;
            // 增加2点生命恢复，虽然看起来不多，其实在游戏里还挺可观的
            // player.lifeRegen += 2;
            player.statManaMax2 += 50;
            player.magicDamage += 0.05f;
            player.manaCost -= 0.2f;
            player.magicCrit += 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBreastplate, 1);
            recipe.AddIngredient(ItemID.MythrilChainmail, 1);
            recipe.AddIngredient(ItemID.AdamantiteBreastplate, 1);
            recipe.AddIngredient(ItemID.HallowedPlateMail, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBreastplate, 1);
            recipe.AddIngredient(ItemID.OrichalcumBreastplate, 1);
            recipe.AddIngredient(ItemID.TitaniumBreastplate, 1);
            recipe.AddIngredient(ItemID.HallowedPlateMail, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
