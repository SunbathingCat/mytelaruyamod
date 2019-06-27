using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class deamonsword : ModItem
    {
        int canusa = 0;
        int timecan = 0;
        bool ccan = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("mojian");
            Tooltip.SetDefault("简单拼凑出来的武器，随时可能会散架...");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 2;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 1.2f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.type != NPCID.TargetDummy)
            {
                ccan = false;
                player.statLife += damage / 5;
                player.HealEffect(damage / 5, true);
                if (player.statLifeMax < 3000)
                {
                    player.statLifeMax += 5;
                }
            } 
        }
        public override void HoldItem(Player player)
        {
            canusa++;
            // player.lifeRegen = 0;
            // player.statDefense += 12;
            player.AddBuff(mod.BuffType("xixie"), 600);
            if (ccan)
            {
                if (canusa >= 20)
                {
                    canusa = 0;
                    if (player.statLifeMax >= 100)
                    {
                        player.statLifeMax -= 1;
                    }
                    /*if (player.statLife > 10)
                    {
                        player.statLife -= 5;
                        // player.KillMe('a',5f,2);
                    }*/
                }
            }
            else
            {
                timecan++;
                if (timecan>=180)
                {
                    timecan = 0;
                    ccan = true;
                }
            }
            base.HoldItem(player);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
