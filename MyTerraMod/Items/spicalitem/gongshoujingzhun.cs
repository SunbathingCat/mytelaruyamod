﻿using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using MyTerraMod.Utilss;

namespace MyTerraMod.Items.spicalitem
{
    public class gongshoujingzhun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("弓手的精准");
            /*
            Tooltip.SetDefault("How are you feeling today?"
                + $"\n[c/FF0000:Colors ][c/00FF00:are ][c/0000FF:fun ]and so are items: [i:{item.type}][i:{mod.ItemType<CarKey>()}][i/s123:{ItemID.TerraBlade}]");
                */
            // Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 4));
            // ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.accessory = true;
            item.rare = 8;
            item.value = Item.sellPrice(0, 5, 0, 0);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int LEL = Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL;
            int gol = LEL * LEL;
            var line = new TooltipLine(mod, "Comm", "移动速度+5% 生命值+10")
            {
                overrideColor = new Color(100, 100, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(mod, "Self", "远程伤害+5% 远程暴击率+2% 防御+2")
            {
                overrideColor = new Color(100, 100, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(mod, "Upgrade", "升级")
            {
                overrideColor = new Color(100, 100, 255)
            };
            tooltips.Add(line);
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")   // mod:文本信息来源于哪个mod，原版的需要== "Terraria"； Name:自定义的名字如"Comm"；text：显示的文本
                {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                    string str = string.Format("弓手的精准 等级{0:D}", LEL);
                    line2.text = str;
                }
                if (line2.mod != "Terraria" && line2.Name == "Comm")
                {
                    string str = string.Format("移动速度+{0:D}% 生命值+{1:D} 防御+{2:D}", 5 * LEL, 10 * LEL, 2 * LEL);
                    line2.text = str;
                }
                if (line2.mod != "Terraria" && line2.Name == "Self")
                {
                    string str = string.Format("远程伤害+{0:D}% 远程暴击率+{1:D}%", 5 * LEL, 2 * LEL);
                    line2.text = str;
                }
                if (line2.mod != "Terraria" && line2.Name == "Upgrade")
                {
                    if (LEL < 10 && Main.LocalPlayer.CanBuyItem(100000 * LEL * LEL))
                    {
                        string str = string.Format("右键点击升级,花费{0:D}金币", gol * 10);
                        line2.text = str;
                        line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                    }
                    else
                    {
                        string str = string.Format("下次升级需{0:D}金币", gol * 10);
                        line2.text = str;
                    }
                }
            }
            if (LEL == 10)
            {
                tooltips.RemoveAll(l => l.Name.EndsWith("Upgrade"));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage += (0.05f * Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL);  // 0.5
            player.rangedCrit += (2 * Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL);   // 20

            player.statDefense += (2 * Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL);
            player.moveSpeed += (0.05f * Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL);   // 0.5
            player.statLifeMax2 += (10 * Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL);   // 100
        }

        public override bool CanRightClick()
        {
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL < 10 && Main.LocalPlayer.CanBuyItem(100000 * Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL * Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL, -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void RightClick(Player player)
        {
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL < 10)
            {
                player.QuickSpawnItem(mod.ItemType("gongshoujingzhun"));
                Main.LocalPlayer.BuyItem(100000 * Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL * Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL);
                Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL++;
                if (Main.LocalPlayer.GetModPlayer<MyPlayer>().sheshouLeL != 10)
                {
                    Main.NewText("升级成功");
                }
                else
                {
                    Main.NewText("升级成功,已达满级", 200, 200, 0);
                }
            }
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ExampleItem"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
