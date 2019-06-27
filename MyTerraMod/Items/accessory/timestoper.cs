using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using MyTerraMod.Utilss;
namespace MyTerraMod.Items.accessory
{
    public class timestoper : ModItem
    {
        int t = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("时间停止器");
            Tooltip.SetDefault("维持时间停止状态需要每分钟（游戏内时间）支付10银币");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.accessory = true;
            item.rare = 8;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.expert = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            t++;
            if (player.CanBuyItem(1000, -1))
            {
                MyWorld.TimePaused = true;
                if (t >= 60)
                {
                    player.BuyItem(1000, -1);
                    t = 0;
                }
            }
            else
            {
                MyWorld.TimePaused = false;
                if(t==120)
                {
                    Main.NewText("余额不足，时间停止已失效");
                    t = 0;
                }
            }
             
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.StoneBlock, 2);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }*/
    }
}
