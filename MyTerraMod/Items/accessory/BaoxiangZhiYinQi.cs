using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MyTerraMod.Utilss;

namespace MyTerraMod.Items.accessory
{
    public class BaoxiangZhiYinQi : ModItem
    {
        string[] BaoXiang = new string[] { "神庙", "冰霜", "神圣", "血腥", "腐化", "丛林" };
        bool a = false;
        int t = 0;
        short fra;
        short fra2;
        Vector2 abc;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("宝箱寻找器");
            Tooltip.SetDefault("寻找宝箱，右键切换宝箱类型");
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

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int opt = Main.LocalPlayer.GetModPlayer<MyPlayer>().baoxiang;
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")   // mod:文本信息来源于哪个mod，原版的需要== "Terraria"； Name:自定义的名字如"Comm"；text：显示的文本
                {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                    string str = string.Format("{0}宝箱寻找器", BaoXiang[opt]);
                    line2.text = str;
                }
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            t++;
            /*
            int x = Main.spawnTileX;
            int y = Main.spawnTileY;
            if (a)
            {
                
                for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
                {
                    Chest chest = Main.chest[chestIndex];
                    // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                    if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 11 * 36)
                    {
                        string str = string.Format("X{0:D} Y{1:D}", Main.mapMaxX/2 - chest.x/16,chest.y/16);//Main.worldSurface
                        Main.NewText(str);
                        a = false;
                        break;
                    }
                }
                a=false;
            }
            */
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().baoxiang == 0)
            {
                fra = 16*36;
                fra2 = 16*36;
            }
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().baoxiang == 1)
            {
                fra = 22 * 36;
                fra2 = 27 * 36;
            }
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().baoxiang == 2)
            {
                fra =  21* 36;
                fra2 =  26* 36;
            }
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().baoxiang == 3)
            {
                fra = 20*36;
                fra2 = 25*36;
            }
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().baoxiang == 4)
            {
                fra = 19*36;
                fra2 = 24*36;
            }
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().baoxiang == 5)
            {
                fra = 18*36;
                fra2 = 23*36;
            }
            if (t > 120)
            {
                for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
                {
                    Chest chest = Main.chest[chestIndex];
                    // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                    if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && (Main.tile[chest.x, chest.y].frameX == fra || Main.tile[chest.x, chest.y].frameX == fra2))
                    {
                        abc = new Vector2(chest.x * 16, chest.y * 16);
                        a = true;
                        break;
                    }
                }
                if (abc.X!=0 && abc.Y!=0)
                {
                    Vector2 toTarget = abc - player.Center;
                    toTarget.Normalize();
                    toTarget *= 3f;
                    // toTarget = toTarget.RotatedBy(0.15f);
                    Projectile.NewProjectile(player.Center,
                                              toTarget, mod.ProjectileType("arrwy"), 0, 0f, Main.myPlayer);
                    t = 0;
                }
                else
                {
                    Main.NewText("没有找到符合要求的箱子");
                    t = 0;
                }
            }
            if(Vector2.Distance(player.position, abc) < 700f && t<=60)
            {
                for (int i = 0; i < 3; i++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height,
                        MyDustId.PurpleLight, -player.velocity.X * 0.5f, -player.velocity.Y * 0.5f, 100, Color.White, 1.0f);
                }
            }
        }

        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
        {
            abc = new Vector2(0, 0);
            player.QuickSpawnItem(mod.ItemType("BaoxiangZhiYinQi"));
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().baoxiang < 5)
            {
                Main.LocalPlayer.GetModPlayer<MyPlayer>().baoxiang++;
            }
            else
            {
                Main.LocalPlayer.GetModPlayer<MyPlayer>().baoxiang=0;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MechanicalBatteryPiece);
            recipe.AddIngredient(ItemID.MechanicalWheelPiece);
            recipe.AddIngredient(ItemID.MechanicalWagonPiece);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
