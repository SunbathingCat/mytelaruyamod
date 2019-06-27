using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace MyTerraMod.Items.Potions
{
     public class PanTao : ModItem
    {
        public override void SetStaticDefaults()
        {
            // 物品名字
            DisplayName.SetDefault("蟠桃");

            // 物品描述
            Tooltip.SetDefault("一个不过瘾再来一个！\n"+"治疗100点生命值并且不会得药水疾病");
        }

        // 最最最重要的物品基本属性部分
        public override void SetDefaults()
        {
            // 下面这些你们应该懂得
            item.width = 14;
            item.height = 24;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;

            // 物品的使用方式，还记得2是什么吗
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.rare = 5;
            item.value = Item.sellPrice(0, 0, 50, 0);

            // *新增-决定这个物品使用以后会不会减少，true就是使用后物品会少一个，默认为false
            item.consumable = true;

            // *新增-决定使用动画出现后，玩家转身会不会影响动画的方向，true就是会，默认为false
            item.useTurn = true;

            // *新增-告诉TR内部系统，这个物品是一个生命药水物品，用于TR系统的特殊目的（比如一键喝药水），默认为false
            // item.potion = false;

            // *新增-这个药水能给玩家加多少血，跟potion一起使用喝完药就会有抗药性debuff
            item.healLife = 100;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
