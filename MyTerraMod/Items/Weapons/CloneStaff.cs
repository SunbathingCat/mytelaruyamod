using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class CloneStaff : ModItem
    {
        int a = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("克隆法杖");
            Tooltip.SetDefault("被复制的物品放第一栏，每复制一次需花费该物品价值的10倍");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 0;
            item.magic = true;
            item.mana = 100;
            item.width = 40;
            item.height = 40;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 0;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
        public override bool CanUseItem(Player player)
        {
            // if (player.inventory[0].stack >= 1 && ((player.inventory[1].type == ItemID.GoldCoin && player.inventory[1].stack >= 20) || (player.inventory[1].type == ItemID.PlatinumCoin && player.inventory[1].stack >= 1)))
            if (player.inventory[0].stack >= 1 && player.CanBuyItem(player.inventory[0].value * 10,-1) && player.statMana>=100)
            {
                player.BuyItem(player.inventory[0].value * 10, -1);
				player.QuickSpawnItem(player.inventory[0].type);
                // Item.NewItem(player.position, player.inventory[0].type, 1);
                // Main.NewText(player.inventory[0].value * 10);
                return base.CanUseItem(player);
            }
            else
            {
                return false;
            }

        }
        /* int timerClone = 59;
        public override bool UseItem(Player player)
        {
            timerClone++;
            if (timerClone == 60)
            {
                timerClone = 0;
                Item.NewItem(player.position, player.inventory[0].type, 1);
                // player.BuyItem(player.inventory[0].value * 10, -1);
                // Main.NewText(player.taxMoney);
                Main.NewText(player.inventory[0].value);
                // player.inventory[1].stack -= 20;
                return base.UseItem(player);
            }
            else
            {
                return false;
            }
        }*/
        public override void HoldItem(Player player)
        {
            a++;
            if (a <= 1)
            {
                if (player.inventory[0].stack >= 1)
                {
                    int cop = (player.inventory[0].value * 10) % 100;
                    int sil = ((player.inventory[0].value * 10) % 10000 - cop) / 100;
                    int gol = ((player.inventory[0].value * 10) % 1000000 - sil) / 10000;
                    int pul = (player.inventory[0].value * 10) / 1000000;
                    if (player.CanBuyItem(player.inventory[0].value * 10, -1))
                    {
                        string str = string.Format("需要铂金币{0:D} 金币{1:D} 银币{2:D} 铜币{3:D} 当前余额充分，可以复制", pul, gol, sil, cop);
                        Main.NewText(str,0,200,0);
                    }
                    else
                    {
                        string str = string.Format("需要铂金币{0:D} 金币{1:D} 银币{2:D} 铜币{3:D} 当前余额不足，不可复制", pul, gol, sil, cop);
                        Main.NewText(str,200,0,0);
                    }
                }
                else
                {
                    Main.NewText("第一栏放置要复制的物品",200,0,0);
                }
            }
            if (a == 180)
            {
                a = 0;
            }
        }
    }
}
