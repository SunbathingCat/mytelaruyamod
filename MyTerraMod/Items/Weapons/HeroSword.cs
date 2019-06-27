﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class HeroSword : ModItem
    {
        int canuse = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("原版英雄剑");
            Tooltip.SetDefault("防御加26，每次攻击后有1秒停顿,回复造成伤害的5%生命值");  //The (English) text shown below your weapon's name
        }
        
        public override void SetDefaults()
        {
            item.damage = 10000;
            // item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 20;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.scale = 1.2f;
            item.crit = 10;
            
        }
        public override void HoldItem(Player player)
        {
            canuse++;
            if (canuse>=100)
            {
                canuse = 100;
            }
            player.statDefense += 26;
            // player.endurance += 0.1f;
            // player.moveSpeed += 0.2f;
            // player.lifeRegen += 5;
            base.HoldItem(player);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.type != NPCID.TargetDummy)
            {
                player.statLife += damage / 20;
                player.HealEffect(damage / 20, true);
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        
        public override bool CanUseItem(Player player)
        {
            if (canuse >= 60)
            {
                canuse = 0;
                return base.CanUseItem(player);
            }
            else
            {
                return false;
            }
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(player.position, 1.0f, 1.0f, 1.0f);
        }
    }
}
