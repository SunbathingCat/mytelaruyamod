using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod
{
    public class MyGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public bool NewCursedInferno = false;


        public override void ResetEffects(NPC npc)
        {
            NewCursedInferno = false;
            MyWorld.TimePaused = false;
        }

       public override void SetDefaults(NPC npc)
        {
            // We want our ExampleJavelin buff to follow the same immunities as BoneJavelin
            // npc.buffImmune[mod.BuffType<Buffs.ExampleJavelin>()] = npc.buffImmune[BuffID.BoneJavelin];
            if (npc.boss)
            {
                // npc.lifeMax = npc.lifeMax * 2;
                npc.damage = npc.damage * 2;
            }
            else
            {
                // npc.lifeMax = npc.lifeMax * 2;
                // npc.damage = npc.damage * 2;
            }
            
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (NewCursedInferno)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 100;
                damage = 10;
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Wizard)
            {
                shop.item[nextSlot].SetDefaults(ItemID.HeartStatue);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.StarStatue);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SlimeStatue);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.JellyfishStatue);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.KingStatue);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.QueenStatue);
                nextSlot++;
                
            }
            else if (type == NPCID.GoblinTinkerer)
            {
                shop.item[nextSlot].SetDefaults(ItemID.HermesBoots);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ArcticDivingGear);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("CombatBag"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("FishYoyoConstructionBag"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("HealthmanaBag"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("InformationalBag"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("MiscellaneousVanityBag"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("MovementBag"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("MountsBag"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("PetBag"));
                nextSlot++;
            }
            else if (type == NPCID.Merchant)
            {
                shop.item[nextSlot].SetDefaults(ItemID.RecallPotion);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.TeleportationPotion);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.WormholePotion);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.GoldChest);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.IceChest);
                nextSlot++;
                if (Main.bloodMoon && Main.rand.Next(2) == 0)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MoneyTrough);
                    nextSlot++;
                }
                if (Main.moonPhase == 0)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MagicMirror);
                    nextSlot++;
                    if (Main.rand.Next(2) == 0)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.GoldenFishingRod);
                        nextSlot++;
                    }
                } 
                else if (Main.moonPhase == 4)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.IceMirror);
                    nextSlot++;
                    if (Main.rand.Next(2) == 1)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.GoldenBugNet);
                        nextSlot++;
                    }
                }
            }
            else if (type == NPCID.Mechanic)
            {
                shop.item[nextSlot].SetDefaults(ItemID.DartTrap);
                nextSlot++;
                if (NPC.downedGolemBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.SuperDartTrap);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SpearTrap);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SpikyBallTrap);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FlameTrap);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.GeyserTrap);
                    nextSlot++;
                }
                
            }
            else if (type == NPCID.Dryad)
            {
                if (Main.bloodMoon)
                {
                    if (WorldGen.crimson)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.VilePowder);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.CorruptSeeds);
                        nextSlot++;
                    }
                    else
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.ViciousPowder);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.CrimsonSeeds);
                        nextSlot++;
                    }
                }
                shop.item[nextSlot].SetDefaults(ItemID.DaybloomSeeds);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.DeathweedSeeds);
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MoonglowSeeds);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BlinkrootSeeds);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.WaterleafSeeds);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.ShiverthornSeeds);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FireblossomSeeds);
                    nextSlot++;
                }
            }
            else if (type == NPCID.WitchDoctor)
            {

            }
            else if (type == NPCID.ArmsDealer)
            {
                if (Main.bloodMoon)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.SharkToothNecklace);
                    nextSlot++;
                }

            }
            else if (type == NPCID.Truffle)
            {
                shop.item[nextSlot].SetDefaults(ItemID.MushroomGrassSeeds);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
                nextSlot++;
            }
            else if (type == NPCID.Demolitionist)
            {
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Beenade);
                    nextSlot++;
                }
            }
            else if (type == NPCID.Pirate)
            {
                if (Main.moonPhase == 0)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.DiscountCard);
                        nextSlot++;
                    }     
                }
                if (Main.moonPhase == 4)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.LuckyCoin);
                        nextSlot++;
                    }
                }
            }
        }
    }
    internal class SpawnRateMultiplierGlobalNPC : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().xieezhixin)
            {
                spawnRate = (int)(spawnRate / 10f);
                maxSpawns = (int)(maxSpawns * 10f);
            }
            else
            {
                spawnRate = (int)(spawnRate / 1f);
                maxSpawns = (int)(maxSpawns * 1f);
            }

            if (!MyWorld.TimePaused)
            {
                MyWorld.PausedTime = Main.time;
            }
            else
            {
                Main.time = MyWorld.PausedTime;
            }

            if (player.ZoneSkyHeight)
            {
                player.AddBuff(BuffID.NoBuilding, 5);
            }
        }
    }
}
