using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MyTerraMod.Items.Armor.spectral
{
    [AutoloadEquip(EquipType.Head)]
    public class spectral_headgear : ModItem
    {
        Vector2 playerPosition= new Vector2(0,-20);
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("鬼魂头盔");
            Tooltip.SetDefault("最大魔法值增加120" +
                "\n魔法伤害增加15%" +
                "\n魔法暴击率增加15%" + 
                "\n魔法值消耗降低10%");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 2;
            item.defense = 15;
        }
        public override void UpdateEquip(Player player)
        {
            // 免疫灼伤debuff
            // player.buffImmune[BuffID.OnFire] = true;
            // 增加生命上限50
            // player.statLifeMax2 += 50; 
            // 增加2点生命恢复，虽然看起来不多，其实在游戏里还挺可观的
            // player.lifeRegen += 2;
            player.noKnockback = true;
            player.manaMagnet = true;
            player.statManaMax2 += 120;
            player.magicDamage += 0.15f;
            player.magicCrit += 15;
            player.manaCost -= 0.1f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("spectral_armor") && legs.type == mod.ItemType("spectral_subligar");
        }
        public override void UpdateArmorSet(Player player)
        {
            // 套装描述，就是鼠标移上去最底下现实的套装效果
            player.setBonus = "。。。" +
                "\n。。。";
            // player.endurance += 0.1f;
            // player.lifeRegen += 2;
            // player.lifeMagnet = true;
            // 加点特技
            // player.armorEffectDrawShadow = true;
            // player.manaCost -= 0.23f;
            // player.gravity = 0f;
            player.statDefense += player.statMana / 10;
            player.GetModPlayer<MyPlayer>().spectral = true;
            player.AddBuff(mod.BuffType("spectrall"), 5);
            player.buffImmune[BuffID.Suffocation] = true;
            player.noFallDmg = true;
            player.statLifeMax2 += 100;
            if (MyTerraMod.SpecialKey.JustPressed)
            {
                // Main.NewText("激活");
                if (player.statMana >= 100 && Vector2.Distance(player.Center, Main.MouseWorld) <= 500f)
                {
                    player.Teleport(Main.MouseWorld+playerPosition,2);
                    // player.AddBuff(BuffID.Featherfall, 30);
                    // player.AddBuff(164, 15);
                    player.AddBuff(mod.BuffType("nogravity"), 20);
                    player.statMana -= 100;
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltHat, 1);
            recipe.AddIngredient(ItemID.MythrilHood, 1);
            recipe.AddIngredient(ItemID.AdamantiteHeadgear, 1);
            recipe.AddIngredient(ItemID.HallowedHeadgear, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumHeadgear, 1);
            recipe.AddIngredient(ItemID.OrichalcumHeadgear, 1);
            recipe.AddIngredient(ItemID.TitaniumHeadgear, 1);
            recipe.AddIngredient(ItemID.HallowedHeadgear, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
