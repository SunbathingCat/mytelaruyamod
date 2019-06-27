using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items
{
    public class BossBag : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag)
            {
                player.QuickSpawnItem(ItemID.MagicMirror, 1);
				player.QuickSpawnItem(mod.ItemType("CloneStaff"), 1);
            }
            if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
            {
                player.QuickSpawnItem(ItemID.MasterNinjaGear, 1);
            }
            if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag)
            {
                if (Main.rand.Next(0, 5) == 2)
                {
                    player.QuickSpawnItem(mod.ItemType("MoJie"), 1);
                }
            }
            if (context == "bossBag" && arg == ItemID.PlanteraBossBag)
            {
                player.QuickSpawnItem(mod.ItemType("PanTao"), Main.rand.Next(5,11));
            }
            if (context == "bossBag" && arg == ItemID.GolemBossBag)
            {
                player.QuickSpawnItem(mod.ItemType("InvincibleHuFu"), Main.rand.Next(10, 31));
            }
            if (context == "bossBag" && arg == ItemID.BrainOfCthulhuBossBag)
            {
                if (Main.rand.Next(0, 3) == 1)
                {
                    player.QuickSpawnItem(mod.ItemType("HuoHuLu"), 1);
                }
            }
            if (context == "bossBag" && arg ==ItemID.EaterOfWorldsBossBag)
            {
                if (Main.rand.Next(0, 3) == 1)
                {
                    player.QuickSpawnItem(mod.ItemType("HuoHuLu"), 1);
                }
            }
        }
    }
}
