using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MyTerraMod.Utilss;

namespace MyTerraMod.Items.accessory
{
    public class flashshoes : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("电靴");
            Tooltip.SetDefault("增度");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.accessory = true;
            item.defense = 10;
            item.rare = 8;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.expert = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // player.moveSpeed += 0.5f;
            player.maxRunSpeed += 50f;
            // player.runAcceleration += 0.02f;
            // player.jumpSpeedBoost += 0.7f;
            if (Math.Abs(player.velocity.X) > 10f && Math.Abs(player.velocity.X) < 30f)
            {
                player.AddBuff(BuffID.OnFire, 60);
                for (int i = 0; i < 2; i++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height,
                    MyDustId.YellowWhiteBubble, -player.velocity.X * 0.5f, -player.velocity.Y * 0.5f, 100, Color.White, 1.0f);
                }
            }
            if (Math.Abs(player.velocity.X) > 20)
            {
                player.AddBuff(BuffID.Burning, 180);
                for (int i = 0; i < 10; i++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height,
                    MyDustId.YellowWhiteBubble, -player.velocity.X * 0.5f, -player.velocity.Y * 0.5f, 100, Color.White, 1.0f);
                }
            }
        }
    }
}
