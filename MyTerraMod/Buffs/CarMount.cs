﻿using Terraria;
using Terraria.ModLoader;

namespace MyTerraMod.Buffs
{
    public class CarMount : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Car");
            Description.SetDefault("Leather seats, 4 cup holders");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(mod.MountType<Mounts.MCar>(), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}