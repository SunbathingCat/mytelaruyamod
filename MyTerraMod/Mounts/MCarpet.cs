using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace MyTerraMod.Mounts
{
    public class MCarpet : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.spawnDust = DustID.Grass;
            mountData.buff = mod.BuffType("CarpetMount");
            mountData.heightBoost = 20;
            mountData.fallDamage = 0.5f;
            mountData.runSpeed = 11f;
            mountData.dashSpeed = 8f;
            mountData.flightTimeMax = 999999;
            mountData.fatigueMax = 999999;
            mountData.jumpHeight = 5;
            mountData.acceleration = 0.19f;
            mountData.jumpSpeed = 4f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 6;
            mountData.constantJump = true;
            mountData.usesHover = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 3;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 13;
            mountData.bodyFrame = 0;
            mountData.yOffset = 35;
            mountData.playerHeadOffset = 22;
            mountData.standingFrameCount = 6;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 6;
            mountData.runningFrameDelay = 12;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 6;
            mountData.flyingFrameDelay = 12;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 6;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 6;
            mountData.idleFrameDelay = 12;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            if (Main.netMode != 2)
            {
                mountData.textureWidth = mountData.backTexture.Width + 20;
                mountData.textureHeight = mountData.backTexture.Height;
            }
        }
        public override void UpdateEffects(Player player)
        {
            if (player.wet)
            {
                player.buffImmune[mod.BuffType("CarpetMount")] = true;
            }
        }
    }
}
