using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace MyTerraMod.Items.Armor.dragon
{
    [AutoloadEquip(EquipType.Body)]
    public class dragon_breastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("神龙胸甲");
            Tooltip.SetDefault("近战伤害增加5%"
                + "\n近战暴击率增加10%");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 2;
            item.defense = 32;
        }
        public override void UpdateEquip(Player player)
        {
            // 免疫灼伤debuff
            // player.buffImmune[BuffID.OnFire] = true;
            // 增加生命上限50
            // player.statLifeMax2 += 50;
            // 增加2点生命恢复，虽然看起来不多，其实在游戏里还挺可观的
            // player.lifeRegen += 2;
            player.meleeDamage += 0.05f;
            player.meleeCrit += 10;

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

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.PalladiumBreastplate, 1);
            recipe2.AddIngredient(ItemID.OrichalcumBreastplate, 1);
            recipe2.AddIngredient(ItemID.TitaniumBreastplate, 1);
            recipe2.AddIngredient(ItemID.HallowedPlateMail, 1);
            recipe2.AddIngredient(ItemID.SoulofFright, 15);
            recipe2.AddIngredient(ItemID.SoulofMight, 15);
            recipe2.AddIngredient(ItemID.SoulofSight, 15);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
