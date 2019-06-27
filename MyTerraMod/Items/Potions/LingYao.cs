using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace MyTerraMod.Items.Potions
{
    public class LingYao : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("灵药");
            Tooltip.SetDefault("立即回复500点生命值\n" +
                "1分钟内快速回复生命值");
        }
        public override void SetDefaults()
        {

            item.width = 16;
            item.height = 14;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.rare = 5;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.consumable = true;
            item.useTurn = true;

            // 这个物品是一个生命药水物品，用于TR系统的特殊目的（比如一键喝药水），默认为false
            item.potion = true;

            // 这个药水能给玩家加多少血，跟potion一起使用喝完药就会有抗药性debuff
            item.healLife = 500;
            
        }

        public override bool UseItem(Player player)
        {
            // 持续 60000 / 60 = 1000秒
            player.AddBuff(mod.BuffType("LingYaoBuff"), 600);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarOre, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
