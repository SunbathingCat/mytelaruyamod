using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MyTerraMod.Utilss;

namespace MyTerraMod.Items.accessory
{
    public class MoJie : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("魔戒");
            Tooltip.SetDefault("最大生命值加500，法力值加100\n减30%受到的伤害\n增加100%近战伤害及20%暴击率但降低挥速\n增加50%远程伤害\n增加150%魔法伤害及降低20%魔法消耗\n最大召唤量加2\n降低移动速度，但免疫击退");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.accessory = true;
            item.defense = 10;
            item.rare = 8;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.expert = true;
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.StoneBlock, 2);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }*/
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 500;
            player.statManaMax2 += 100;
            player.endurance += 0.3f;
            // player.lifeRegen += 10;
            player.meleeDamage += 1.0f;
            player.rangedDamage += 0.5f;
            player.magicDamage += 1.5f;
            player.meleeCrit += 20;
            player.meleeSpeed -= 1f;
            player.moveSpeed -= 0.5f;
            player.maxRunSpeed -= 6f;
            player.runAcceleration -= 0.02f;
            player.jumpSpeedBoost -= 0.7f;
            //player.name = "神一样的人";
            player.manaCost -= 0.2f;
            player.maxMinions += 2;
            player.noKnockback = true;
            for (int i = 0; i < 3; i++)
            {
                Dust.NewDustDirect(player.position, player.width, player.height,
                    MyDustId.PurpleLight, -player.velocity.X * 0.5f, -player.velocity.Y * 0.5f, 100, Color.White, 1.0f);
            }
        }
    }
}
