using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.NPCs.Ocram
{
    public class Ocram : ModNPC
    {
        bool a = true;
        bool b = true;
        bool c = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Ocram");
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            // aiType = NPCID.AngryNimbus;
            npc.lifeMax = 40000;
            npc.damage = 100;
            npc.defense = 55;
            npc.knockBackResist = 0f;       //免疫
            npc.width = 100;
            npc.height = 100;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.npcSlots = 15f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            music = MusicID.Boss2;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }
        public override void AI()
        {
            //  If Main.netMode == 0, that means it is a singleplayer game. If Main.netMode == 1, then it is a client connected to a server. If Main.netMode == 2, then it is a server.
            npc.TargetClosest(true);
            npc.netUpdate = true;
            Player player = Main.player[npc.target];
            if (npc.life<npc.lifeMax && npc.life >= 3 * npc.lifeMax / 4 && a)
            {
                a = false;
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
                Main.PlaySound(SoundID.Roar, player.position, 0);
            }
            else if (npc.life < 3 * npc.lifeMax / 4 && npc.life >= npc.lifeMax / 2 && b)
            {
                b = false;
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
                Main.PlaySound(SoundID.Roar, player.position, 0);
            }
            else if (npc.life < npc.lifeMax / 2 && npc.life >= 10000 && c)
            {
                c = false;
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
                Main.PlaySound(SoundID.Roar, player.position, 0);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            if (Main.rand.NextBool())
            {
                npc.frame.Y = 1 * frameHeight;
            }
            else
            {
                npc.frame.Y = 0 * frameHeight;
            }
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
    }
}
