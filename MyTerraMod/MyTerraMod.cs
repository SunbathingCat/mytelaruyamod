using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ReLogic.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyTerraMod
{
    public class MyTerraMod : Mod
    {
        internal static MyTerraMod Instance;
        internal UserInterface ExamplePersonUserInterface;
        public static ModHotKey SpecialKey;
        public MyTerraMod()
		{
            // MOD的初始化函数，用来设置一些属性
            // 注意，这跟Load() 函数不一样
            Instance = this;
            /*Properties = new ModProperties()
			{
				// 自动加载贴图什么的
				Autoload = true,

				// 自动加载血块贴图
				AutoloadGores = true,

				// 自动加载声音文件
				AutoloadSounds = true,

				// 自动加载背景图片
				AutoloadBackgrounds = true
			};*/
		}
        public override void Load()
        {
            MyTerraMod.SpecialKey = base.RegisterHotKey("特殊能力", "G");
        }
        public override void AddRecipes()
        {
            /*ModRecipe recipe111 = new ModRecipe(this);
            recipe111.AddIngredient(ItemID.Wood, 2);
            recipe111.AddIngredient(ItemID.WoodenSword);
            recipe111.SetResult(ItemID.WoodenSword,2);
            recipe111.AddRecipe();*/

            /*ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Rope, 100);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.CordageGuide, 1);
            recipe.AddRecipe();*/

            ModRecipe recipe1 = new ModRecipe(this);
            recipe1.AddIngredient(ItemID.SandBlock, 10);
            recipe1.AddTile(TileID.Extractinator);
            recipe1.SetResult(ItemID.GoldOre, 1);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(this);
            recipe2.AddIngredient(ItemID.GoldBar, 1);
            // recipe2.AddIngredient(ItemID.PlatinumBar, 1);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(ItemID.GoldCoin, 5);
            recipe2.AddRecipe();

            ModRecipe recipe3 = new ModRecipe(this);
            recipe3.AddIngredient(ItemID.PlatinumBar, 1);
            recipe3.AddIngredient(ItemID.GoldCoin, 1);
            // recipe3.AddIngredient(ItemID.HallowedBar, 1);
            recipe3.AddTile(TileID.MythrilAnvil);
            recipe3.SetResult(ItemID.PlatinumCoin, 1);
            recipe3.AddRecipe();

            ModRecipe recipe4 = new ModRecipe(this);
            recipe4.AddIngredient(ItemID.GoldBrick, 4);
            recipe4.AddTile(TileID.Furnaces);
            recipe4.SetResult(ItemID.GoldBar, 1);
            recipe4.AddRecipe();

            ModRecipe recipe5 = new ModRecipe(this);
            recipe5.AddIngredient(ItemID.Bone, 100);
            recipe5.AddIngredient(ItemID.DemoniteBar, 15);
            recipe5.AddTile(TileID.Anvils);
            recipe5.SetResult(ItemID.Muramasa, 1);
            recipe5.AddRecipe();

            ModRecipe recipe6 = new ModRecipe(this);
            recipe6.AddIngredient(ItemID.Bone, 100);
            recipe6.AddIngredient(ItemID.DemoniteBar, 15);
            recipe6.AddTile(TileID.Anvils);
            recipe6.SetResult(ItemID.CobaltShield, 1);
            recipe6.AddRecipe();

            ModRecipe recipe7 = new ModRecipe(this);
            recipe7.AddIngredient(ItemID.JungleKey, 1);
            recipe7.AddIngredient(ItemID.GoldCoin, 20);
            recipe7.AddTile(TileID.DemonAltar);
            recipe7.SetResult(ItemID.PiranhaGun, 1);
            recipe7.AddRecipe();

            ModRecipe recipe8 = new ModRecipe(this);
            recipe8.AddIngredient(ItemID.CorruptionKey, 1);
            recipe8.AddIngredient(ItemID.GoldCoin, 20);
            recipe8.AddTile(TileID.DemonAltar);
            recipe8.SetResult(ItemID.ScourgeoftheCorruptor, 1);
            recipe8.AddRecipe();

            ModRecipe recipe9 = new ModRecipe(this);
            recipe9.AddIngredient(ItemID.CrimsonKey, 1);
            recipe9.AddIngredient(ItemID.GoldCoin, 20);
            recipe9.AddTile(TileID.DemonAltar);
            recipe9.SetResult(ItemID.VampireKnives, 1);
            recipe9.AddRecipe();

            ModRecipe recipe10 = new ModRecipe(this);
            recipe10.AddIngredient(ItemID.HallowedKey, 1);
            recipe10.AddIngredient(ItemID.GoldCoin, 20);
            recipe10.AddTile(TileID.DemonAltar);
            recipe10.SetResult(ItemID.RainbowGun, 1);
            recipe10.AddRecipe();

            ModRecipe recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(ItemID.FrozenKey, 1);
            recipe11.AddIngredient(ItemID.GoldCoin, 20);
            recipe11.AddTile(TileID.DemonAltar);
            recipe11.SetResult(ItemID.StaffoftheFrostHydra, 1);
            recipe11.AddRecipe();

        }
    }
}
