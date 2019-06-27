using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MyTerraMod.NPCs
{
    [AutoloadHead]
    public class DiJing : ModNPC
    {
        public override string Texture
        {
            get
            {
                return "MyTerraMod/NPCs/DiJing";
            }
        }
        public override string[] AltTextures
        {
            get
            {
                return new string[] { "MyTerraMod/NPCs/DiJing_Alt_1" };
            }
        }
        public override bool Autoload(ref string name)
        {
            name = "Di Jing";
            return mod.Properties.Autoload;
        }
        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            // DisplayName.SetDefault("Example Person");
            // DiJing.png
            // DiJing_Alt_1.png
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 8;
            NPCID.Sets.AttackFrameCount[npc.type] = 5;
            NPCID.Sets.DangerDetectRange[npc.type] = 100;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 30;
            NPCID.Sets.AttackAverageChance[npc.type] = 100;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 26;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }
        /*public override void HitEffect(int hitDirection, double damage)
        {
            int num = npc.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Sparkle"));
            }
        }*/
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active)
                {
                    for (int j = 0; j < player.inventory.Length; j++)
                    {
                        if (player.inventory[j].type == ItemID.StoneBlock || player.inventory[j].type == ItemID.SandBlock || player.inventory[j].type == ItemID.Wood)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    return "LG";
                case 1:
                    return "Jerome";
                case 2:
                    return "Adonis";
                default:
                    return "Keith";
            }
        }
        public override string GetChat()
        {
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.Next(2) == 0)
            {
                return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?";
            }
            switch (Main.rand.Next(7))
            {
                case 0:
                    return "什么黄金装备？，我不知道，别问我。看着我干什么，我真不知道";
                case 1:
                    return "迟早有一天老大他们会来找我算账的！你一定会帮我的，对吧？";
                case 2:
                    return "以前我跟着老大他们到处寻找宝藏，发了不少财！什么？你们人类管这个叫偷、抢？";
                case 3:
                    return "你说这些材料?，我们在地下越挖越深，什么宝贝没见过";
                case 4:
                    return "我以前可是领头的，谁告诉你我是烧火的";
                case 5:
                    return "我不过是因为拿了黄金..啊，哈哈哈，额，其实是我自己出走的，嗯，对，就是想看看外面世界";
                default:
                    return "在这儿待着真无聊啊，怀念以前烧火的日子。。";
            }
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "clone";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.NewText("被复制的物品放第一栏，第二栏放金币，每复制一次花费20金");
                MyTerraMod.Instance.ExamplePersonUserInterface.SetState(new UI.ExamplePersonUI());
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.Gel);
            shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.ClayBlock);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.DirtBlock);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.StoneBlock);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Wood);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.SandBlock);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.SnowBlock);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.MudBlock);
            nextSlot++;

            if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.GreenBrick);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.PinkBrick);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.BlueBrick);
                nextSlot++;
            }

            if (NPC.downedQueenBee)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Hive);
                nextSlot++;
            }
            if (NPC.downedGoblins)
            {
                shop.item[nextSlot].SetDefaults(ItemID.CopperOre);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.IronOre);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SilverOre);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.GoldOre);
                nextSlot++;
            }
            if (NPC.downedBoss2 || NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Meteorite);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.CrimtaneOre);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.DemoniteOre);
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Granite);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Marble);
                nextSlot++;
            }
            if (NPC.downedMechBoss1&&Main.dayTime)
            {
                shop.item[nextSlot].SetDefaults(ItemID.CobaltOre);
                nextSlot++;
            }
            if (NPC.downedMechBoss1&&!Main.dayTime)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PalladiumOre);
                nextSlot++;
            }
            if (NPC.downedMechBoss2 && Main.dayTime)
            {
                shop.item[nextSlot].SetDefaults(ItemID.MythrilOre);
                nextSlot++;
            }
            if (NPC.downedMechBoss2 && !Main.dayTime)
            {
                shop.item[nextSlot].SetDefaults(ItemID.OrichalcumOre);
                nextSlot++;
            }
            if (NPC.downedMechBoss3 && Main.dayTime)
            {
                shop.item[nextSlot].SetDefaults(ItemID.AdamantiteOre);
                nextSlot++;
            }
            if (NPC.downedMechBoss3 && !Main.dayTime)
            {
                shop.item[nextSlot].SetDefaults(ItemID.TitaniumOre);
                nextSlot++; 
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.HallowedBar);
                nextSlot++;
            }
            if (NPC.downedPlantBoss)
            {
                shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteOre);
                nextSlot++;
            }
            if (NPC.downedMoonlord&&!Main.dayTime)
            {
                shop.item[nextSlot].SetDefaults(ItemID.LunarOre);
                nextSlot++;
            }
            if (NPC.downedGolemBoss)
            {
                shop.item[nextSlot].SetDefaults(ItemID.LihzahrdBrick);
                nextSlot++;
            }


            if (Main.moonPhase < 1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Amber);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Cloud);
                nextSlot++;
            }
            else if (Main.moonPhase < 2)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Emerald);
                nextSlot++;

            }
            else if (Main.moonPhase < 3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Ruby);
                nextSlot++;
                

            }
            else if (Main.moonPhase < 4)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Diamond);
                nextSlot++;
            }
            else if (Main.moonPhase < 5)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Sapphire);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.RainbowBrick);
                    nextSlot++;
                }
            }
            else if (Main.moonPhase < 6)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Amethyst);
                nextSlot++;
            }
            else if (Main.moonPhase < 7)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Topaz);
                nextSlot++;
            }
            else 
            {
                shop.item[nextSlot].SetDefaults(ItemID.PinkGel);
                nextSlot++;
            }
            // Here is an example of how your npc can sell items from other mods.
            /*if (ModLoader.GetLoadedMods().Contains("SummonersAssociation"))
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SummonersAssociation").ItemType("BloodTalisman"));
                nextSlot++;
            }*/
        }
        public override void NPCLoot()
        {
            int num = Main.rand.Next(10);
            if (num == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.GoldAxe);
                Item.NewItem(npc.getRect(), ItemID.GoldPickaxe);
                Item.NewItem(npc.getRect(), ItemID.GoldHammer);
            }
            else if (num == 1)
            {
                Item.NewItem(npc.getRect(), ItemID.GoldBroadsword);
                Item.NewItem(npc.getRect(), ItemID.GoldBow);
            }
            else if (num == 2)
            {
                Item.NewItem(npc.getRect(), ItemID.GoldCoin, Main.rand.Next(21));
            }
            else if (num == 3)
            {
                Item.NewItem(npc.getRect(), ItemID.GoldHelmet);
                Item.NewItem(npc.getRect(), ItemID.GoldChainmail);
                Item.NewItem(npc.getRect(), ItemID.GoldGreaves);
            }
            else if (num == 4)
            {
                Item.NewItem(npc.getRect(), ItemID.GoldChest);
            }
            else
            {
                Item.NewItem(npc.getRect(), ItemID.GoldOre, Main.rand.Next(20,51));
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.JavelinFriendly;
            attackDelay = 1;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}
