using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;


using Microsoft.Xna.Framework.Input;
using System.Security.Cryptography;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Tile_Entities;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace MyTerraMod
{
    public class MyPlayer : ModPlayer
    {
        public float stealth;
        public float defenseEffect = -1f;
        int ttt = 3600*2;
        // NPC[] tag = new NPC[10];
        // int i = 0;
        public bool dragon = false;
        public bool titan = false;
        public bool spectral = false;
        public bool taiji = false;

        public int zhanshiLeL = 1;
        public int sheshouLeL = 1;
        public int fashiLeL = 1;

        public int baoxiang = 0;

        public bool xieezhixin = false;
        /* public int[] doubleTapCardinalTimer = new int[4];
         public bool controlUp = false;
         public bool controlLeft = false;
         public bool controlDown = false;
         public bool controlRight = false;
         public bool controlJump = false;
         public bool releaseLeft;
         public bool releaseRight;
         public bool releaseDown;
         public bool releaseUp;*/

        public override void ResetEffects()
        {
            stealth = 1.0f;
            defenseEffect = 0.5f;
            dragon = false;
            titan = false;
            spectral = false;
            taiji = false;
            xieezhixin = false;
            
            /*if (this.controlRight)
            {
                this.releaseRight = false;
            }
            else
            {
                this.releaseRight = true;
            }
            if (this.controlLeft)
            {
                this.releaseLeft = false;
            }
            else
            {
                this.releaseLeft = true;
            }
            this.releaseDown = !this.controlDown;*/
        }
        public override void UpdateBadLifeRegen()
        {
            ttt++;
            if (dragon && ttt >= 3600*2) //minite
            {
                player.AddBuff(mod.BuffType("dragenn"), 5);
            }
            if (ttt > 10000)
            {
                ttt = 10000;
            }

            
        }
        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
        {
            if (stealth < 1.0f)
            {
                float scale = stealth;
                scale = MathHelper.Clamp(stealth, 0.0f, 1.0f);
                drawInfo.eyeWhiteColor = Color.Multiply(drawInfo.eyeWhiteColor, scale);
                drawInfo.eyeColor = Color.Multiply(drawInfo.eyeColor, scale);
                drawInfo.hairColor = Color.Multiply(drawInfo.hairColor, scale);
                drawInfo.faceColor = Color.Multiply(drawInfo.faceColor, scale);
                drawInfo.bodyColor = Color.Multiply(drawInfo.bodyColor, scale);
                drawInfo.legColor = Color.Multiply(drawInfo.legColor, scale);
                drawInfo.shirtColor = Color.Multiply(drawInfo.shirtColor, scale);
                drawInfo.underShirtColor = Color.Multiply(drawInfo.underShirtColor, scale);
                drawInfo.pantsColor = Color.Multiply(drawInfo.pantsColor, scale);
                drawInfo.shoeColor = Color.Multiply(drawInfo.shoeColor, scale);
                drawInfo.headGlowMaskColor = Color.Multiply(drawInfo.headGlowMaskColor, scale);
                drawInfo.bodyGlowMaskColor = Color.Multiply(drawInfo.bodyGlowMaskColor, scale);
                drawInfo.legGlowMaskColor = Color.Multiply(drawInfo.legGlowMaskColor, scale);
                drawInfo.armGlowMaskColor = Color.Multiply(drawInfo.armGlowMaskColor, scale);
                drawInfo.upperArmorColor = Color.Multiply(drawInfo.upperArmorColor, scale);
                drawInfo.lowerArmorColor = Color.Multiply(drawInfo.lowerArmorColor, scale);
                drawInfo.middleArmorColor = Color.Multiply(drawInfo.middleArmorColor, scale);
                // 减少仇恨
                player.aggro = -500;
            }
        }
        public override void SetupStartInventory(IList<Item> items)
        {
            if (player.name == "LG")
            {
                Item item = new Item();
                item.SetDefaults(mod.ItemType("SecretKey"));
                item.stack = 5;
                items.Add(item);
            }
            else
            {
                Item item = new Item();
                item.SetDefaults(mod.ItemType("StartBag"));
                item.stack = 1;
                items.Add(item);
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (defenseEffect >= 0f)
            {
                if (Main.expertMode)
                {
                    defenseEffect *= 2;
                }
                damage -= (int)(player.statDefense * defenseEffect);
                if (damage < 0)
                {
                    if (-damage < player.statDefense / 5)
                    {
                        damage = 1;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (dragon && player.statLife < player.statLifeMax2/2 && damage > 10)
                {
                    damage = 10;
                }
                if (taiji && Main.rand.NextBool())
                {
                    Main.NewText("躲避");
                    return false;
                }
                customDamage = true;
            }

            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (spectral == true && proj.magic == true)
            {
                NPC[] tag = new NPC[20];
                int i = 0;
                if (target.type != NPCID.TargetDummy && target.active && !target.friendly && target.type!=NPCID.DD2LanePortal)
                {
                    if (damage / 10 > 0)
                    {
                        player.statLife += damage / 40;
                        player.HealEffect(damage / 40, true);
                    }
                    else
                    {
                        player.statLife += 1;
                        player.HealEffect(1, true);
                    }
                }
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && npc.type != NPCID.DD2LanePortal && npc.type != NPCID.TargetDummy && !npc.friendly && Vector2.Distance(npc.Center, target.Center) < 150f && npc!=target)
                    {
                        tag[i] = npc;
                        i++;
                    }
                }
                foreach (NPC npc in tag)
                {
                    if (npc != null)
                    {
                        player.ApplyDamageToNPC(npc, proj.damage/3, 2, player.direction, false);
                        Lighting.AddLight(npc.position, 1.0f, 1.0f, 1.0f);
                        Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height
                    , DustID.BlueCrystalShard, 0f, 0f, 100, default(Color), 3f);
                        // 粒子特效不受重力
                        dust.noGravity = true;
                    }
                }
            }
            if (titan == true)
            {
                target.AddBuff(BuffID.Midas, 300);
            }
        }
        /*public override void PreUpdateBuffs()
        {
            if (dragon && player.statLife >= player.statLifeMax2 * 0.5)
            {
                player.AddBuff(mod.BuffType("dragonbuff"), -1);
            }
        }*/
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (dragon && player.HasBuff(mod.BuffType("demagic")))
            {
                player.statLife += damage;
            }
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (dragon && player.HasBuff(mod.BuffType("dragenn")))
            {
                ttt = 0;
                player.statLife = player.statLifeMax2;
                player.HealEffect(player.statLifeMax2);
                player.immune = true;
                player.immuneTime = player.longInvince ? 180 : 120;
                // Main.NewText(player.buffImmune[mod.BuffType("dragenn")]);
                player.buffImmune[mod.BuffType("dragenn")] = true;
                // Main.NewText(ttt);
                return false;
            }
            else
            {
                // Main.NewText(dragon);
                // Main.NewText(player.HasBuff(mod.BuffType("dragenn")));
                // damageSource = PlayerDeathReason.ByCustomReason(" was dissolved by holy powers");
                return true;
            }
        }
    }
}
