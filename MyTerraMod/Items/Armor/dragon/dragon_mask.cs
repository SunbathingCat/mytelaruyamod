using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MyTerraMod.Items.Armor.dragon
{
    [AutoloadEquip(EquipType.Head)]
    public class dragon_mask : ModItem
    {
        int tttt = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("神龙头盔");
            Tooltip.SetDefault("近战伤害增加15%" +
                "\n近战速度增加15%" +
                "\n近战暴击率增加15%");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 2;
            item.defense = 23;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.15f;
            player.meleeSpeed += 0.15f;
            player.meleeCrit += 15;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("dragon_breastplate") && legs.type == mod.ItemType("dragon_greaves");
        }
        public override void UpdateArmorSet(Player player)
        {
            tttt++;
            if (tttt>=3600*5)
            {
                tttt = 3600*5;
            }
            if (tttt == 3600*5-1)
            {
                Main.NewText("反魔法护罩已就绪");
            }
            // 套装描述，就是鼠标移上去最底下现实的套装效果
            player.setBonus = "移动速度增加23%" +
                "\n近战速度增加23%" +
                "\n受到致命伤害时恢复至满生命状态，每两分钟内只能触发一次" + 
                "\n生命值大于50%时免疫一切debuff";
            // player.endurance += 0.1f;
            player.lifeRegen += 5;
            // player.lifeMagnet = true;吸取红心范围增大
            // 加点特技
            player.armorEffectDrawShadow = true;
            player.statLifeMax2 += 100;
            player.noKnockback = true;
            player.lifeMagnet = true;
            player.moveSpeed += 0.23f;
            player.meleeSpeed += 0.23f;
            // player.wingTime = 0;
            // player.rocketTime = 0;
            // player.breathMax = 0;
            player.GetModPlayer<MyPlayer>().dragon = true;
            if (player.statLife >= player.statLifeMax2 * 0.5)
            {
                player.AddBuff(mod.BuffType("dragonbuff"), 2);
            }
            else
            {
                player.AddBuff(mod.BuffType("dragonzs"), 2);
                
            }
            if (MyTerraMod.SpecialKey.JustPressed)
            {
                // Main.NewText("激活");
                if (tttt>=3600*5)
                {
                    Main.NewText("反魔法护罩已激活");
                    player.AddBuff(mod.BuffType("demagic"), 3600);
                    tttt=0;
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltHelmet, 1);
            recipe.AddIngredient(ItemID.MythrilHelmet, 1);
            recipe.AddIngredient(ItemID.AdamantiteHelmet, 1);
            recipe.AddIngredient(ItemID.HallowedMask, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumMask, 1);
            recipe.AddIngredient(ItemID.OrichalcumMask, 1);
            recipe.AddIngredient(ItemID.TitaniumMask, 1);
            recipe.AddIngredient(ItemID.HallowedMask, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
