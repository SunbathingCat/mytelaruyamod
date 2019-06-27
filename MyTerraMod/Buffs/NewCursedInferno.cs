using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MyTerraMod.Utilss;
namespace MyTerraMod.Buffs
{
	public class NewCursedInferno : ModBuff
	{
		// 设置buff基本属性的地方，跟物品的SetDefault很像呢
		public override void SetDefaults()
		{
			// 设置buff名字和描述
			DisplayName.SetDefault("绿光");
			Description.SetDefault("爱是一道光。。。");

			// 因为buff严格意义上不是一个TR里面自定义的数据类型，所以没有像buff.XXXX这样的设置属性方式了
			// 我们需要用另外一种方式设置属性

			// 这个属性决定buff在游戏退出再进来后会不会仍然持续，true就是不会，false就是会
			Main.buffNoSave[Type] = false;

			// 用来判定这个buff算不算一个debuff，如果设置为true会得到TR里对于debuff的限制，比如无法取消
			Main.debuff[Type] = true;

			// 当然你也可以用这个属性让这个buff即使不是debuff也不能取消，设为false就是不能取消了
			this.canBeCleared = false;

			// 决定这个buff是不是照明宠物的buff，以后讲宠物和召唤物的时候会用到的，现在先设为false
			Main.lightPet[Type] = false;

			// 决定这个buff会不会显示持续时间，false就是会显示，true就是不会显示，一般宠物buff都不会显示
			Main.buffNoTimeDisplay[Type] = false;

			// 决定这个buff在专家模式会不会持续时间加长，false是不会，true是会
			this.longerExpertDebuff = true;

			// 如果这个属性为true，pvp的时候就可以给对手加上这个debuff/buff
			Main.pvpBuff[Type] = true;

			// 决定这个buff是不是一个装饰性宠物，用来判定的，比如消除buff的时候不会消除它
			Main.vanityPet[Type] = false;


		}

		public override void Update(NPC npc, ref int buffIndex)
		{
            for (int i = 0; i < 2; i++)
            {
                Dust dust = Dust.NewDustDirect(npc.Center, npc.width, 10,
                    MyDustId.YellowHallowFx, 0, -2f, 100, Color.White, 1.15f);
                dust.noGravity = true;
            }
            npc.GetGlobalNPC<MyGlobalNPC>(mod).NewCursedInferno = true;
            /*if (npc.lifeRegen > 0) npc.lifeRegen = 0;
            npc.lifeRegen -= 30;*/
            
            //npc.life -= 5;
        }
	}
}
