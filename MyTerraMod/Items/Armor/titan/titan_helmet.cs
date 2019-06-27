using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MyTerraMod.Items.Armor.titan
{
    [AutoloadEquip(EquipType.Head)]
    public class titan_helmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("泰坦头盔");
            Tooltip.SetDefault("这是一个被魔改了的头盔" +
                "\n身体周围会发红光");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 2;
            item.defense = 12;
        }
        public override void UpdateEquip(Player player)
        {
            // 免疫灼伤debuff
            // player.buffImmune[BuffID.OnFire] = true;
            // 增加生命上限50
            // player.statLifeMax2 += 50;
            // 增加2点生命恢复，虽然看起来不多，其实在游戏里还挺可观的
            // player.lifeRegen += 2;
            player.rangedDamage += 0.15f;
            player.rangedCrit += 10;
            player.ammoCost75 = true;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("titan_mail") && legs.type == mod.ItemType("titan_leggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            // 套装描述，就是鼠标移上去最底下现实的套装效果
            player.setBonus = "进一步增加回血速度，吸取红心范围增大" +
                "\n增加10%伤害减免";
            // player.endurance += 0.1f;
            // player.lifeRegen += 2;
            // player.lifeMagnet = true;
            // 加点特技
            player.armorEffectDrawShadow = true;
            player.statLifeMax2 += 100;
            player.ammoCost75 = true;
            player.goldRing = true;
            
            // player.turtleArmor = true;
            player.noKnockback = true;
            player.accCompass = 1;
            player.accDepthMeter = 1;
            player.accCalendar = true;
            player.accOreFinder = true;
            player.accCritterGuide = true;
            player.accDivingHelm = true;
            player.accStopwatch = true;
            player.accThirdEye = true;
            player.accWeatherRadio = true;
            player.moveSpeed += 0.2f;
            player.dash = 1;
            player.jumpSpeedBoost += 0.2f;
            player.GetModPlayer<MyPlayer>().titan = true;
            if (player.velocity.Length() > 0.05f)
            {
                player.AddBuff(mod.BuffType("titann"), 5);
                
            }  
            if (MyTerraMod.SpecialKey.JustPressed)
            {
                // Main.NewText("激活");
                if (player.statMana >= 200)
                {
                    Vector2 vec = Main.MouseWorld - player.Center;
                    // 角度变化
                    for (float rad = 0.0f; rad < 2 * 3.141f; rad += 0.3f)
                    {
                        Vector2 finalVec = (vec.ToRotation() + rad).ToRotationVector2() * 16f;
                        // 射出去！
                        Projectile.NewProjectile(player.position, finalVec, mod.ProjectileType("fallstar2"), 1000, 20, player.whoAmI);
                    }
                    player.statMana = 0;
                    player.statLife += 100;
                    player.HealEffect(100, true);
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltMask, 1);
            recipe.AddIngredient(ItemID.MythrilHat, 1);
            recipe.AddIngredient(ItemID.AdamantiteMask, 1);
            recipe.AddIngredient(ItemID.HallowedHelmet, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumHelmet, 1);
            recipe.AddIngredient(ItemID.OrichalcumHelmet, 1);
            recipe.AddIngredient(ItemID.TitaniumHelmet, 1);
            recipe.AddIngredient(ItemID.HallowedHelmet, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
