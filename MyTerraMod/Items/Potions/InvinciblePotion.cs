using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace MyTerraMod.Items.Potions
{
    public class InvinciblePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无敌药水");
            Tooltip.SetDefault("90秒无敌效果");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;
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
            // item.healLife = 50;

            // *新增-加buff的方法1：设置物品的buffType为buff的ID
            // 这里我设置了着火debuff（2333
            // item.buffType = BuffID.OnFire;

            // *新增-用于在物品描述上显示buff持续时间
            item.buffTime = 5400;
        }

        

        /* 最最最重要的部分，这个函数发生在玩家使用这个物品的时候，除了SetDefault里面的几个属性以外
		 * 自定义药水喝完以后的效果就需要在这个函数里面完成了
		 * 这个函数可以对Player（玩家）的属性进行修改 */
        public override bool UseItem(Player player)
        {

            // 持续 5400 / 60 = 90秒
            player.AddBuff(mod.BuffType("invincible"), 5400);
            

            // 嘿嘿
            // player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " 喝农药被毒死了"), 9999, 0);

            // 这个函数有一个布尔类型返回值（还记得是啥吗
            // 返回true就说明使用成功了（其实没啥用，顶多用来判定），false是默认值
            // 但是你不写返回值就会报错
            return true;
        }
        // 给物品加合成表
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "InvincibleHuFu", 10);
            recipe.AddIngredient(ItemID.GreaterHealingPotion, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
