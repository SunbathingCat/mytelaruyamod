using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace MyTerraMod
{
    public class MyWorld : ModWorld
    {
        public static bool downedOcram;
        public static bool TimePaused;
        public static double PausedTime = 0;
        public override void Initialize()
        {
            MyWorld.downedOcram = false;
        }
        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedOcram)
            {
                downed.Add("Ocram");
            }
            TagCompound tagCompound = new TagCompound();
            tagCompound.Add("downed", downed);
            return tagCompound;
        }
        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedOcram = downed.Contains("Ocram");

        }
        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedOcram = flags[0];

            }
            else
            {
                //mod.Logger.WarnFormat("ExampleMod: Unknown loadVersion: {0}", loadVersion);
            }
        }
        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedOcram;

            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedOcram = flags[0];

            // As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
            // BitsByte flags2 = reader.ReadByte();
            // downed9thBoss = flags[0];
        }
        public override void PostWorldGen()
        {
            int x = Main.spawnTileX;
            int y = Main.spawnTileY;
            WorldGen.PlaceTile(x, y - 15, TileID.WoodBlock);
            WorldGen.PlaceTile(x + 1, y - 15, TileID.WoodBlock);
            WorldGen.PlaceTile(x, y - 16, TileID.Containers);
            // WorldGen.PlaceTile(x, y - 16, mod.TileType<Tiles.ADChest>());
            

            int[] itemsToPlaceInIceChests = new int[] { mod.ItemType("SecretKey"), mod.ItemType("SecretKeyA"), mod.ItemType("SecretKeyB"), mod.ItemType("SecretKeyC"), mod.ItemType("SecretKeyD") };
            int itemsToPlaceInIceChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                if (chest != null  && chest.x== Main.spawnTileX)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInIceChests[itemsToPlaceInIceChestsChoice]);
                            itemsToPlaceInIceChestsChoice = (itemsToPlaceInIceChestsChoice + 1);
                            // Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
                           // break;
                           if (itemsToPlaceInIceChestsChoice >= itemsToPlaceInIceChests.Length)
                            {
                                break;
                            }
                        } 
                    }
                }
            }
        }
    }
}
