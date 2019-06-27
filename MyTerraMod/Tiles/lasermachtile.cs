using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MyTerraMod.Tiles
{
    public class lasermachtile : ModTile
    {
        int t = 0;
        int m = 0;
        int pow = 1;
        int k = 0;
        int n = 300;
        // NPC mon = new NPC();
        bool can = true;
        Vector2 spawnPosition;
        Vector2 spawnPosition2;
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new[]
            {
                16,
                16,
                16,
                16,
                16
            };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            // name.SetDefault("Example Clock"); // Automatic from .lang files
            AddMapEntry(new Color(200, 200, 200), name);
            dustType = DustID.Gold;
            adjTiles = new int[] { TileID.GrandfatherClocks };
        }

        public override void RightClick(int x, int y)
        {
            can = !can;
            if(can)
            {
                Main.NewText("激光塔楼已激活");
            }
            else
            {
                Main.NewText("激光塔楼已关闭");
            }
            {
                string text = "AM";
                //Get current weird time
                double time = Main.time;
                if (!Main.dayTime)
                {
                    //if it's night add this number
                    time += 54000.0;
                }
                //Divide by seconds in a day * 24
                time = time / 86400.0 * 24.0;
                //Dunno why we're taking 19.5. Something about hour formatting
                time = time - 7.5 - 12.0;
                //Format in readable time
                if (time < 0.0)
                {
                    time += 24.0;
                }
                if (time >= 12.0)
                {
                    text = "PM";
                }
                int intTime = (int)time;
                //Get the decimal points of time.
                double deltaTime = time - intTime;
                //multiply them by 60. Minutes, probably
                deltaTime = (int)(deltaTime * 60.0);
                //This could easily be replaced by deltaTime.ToString()
                string text2 = string.Concat(deltaTime);
                if (deltaTime < 10.0)
                {
                    //if deltaTime is eg "1" (which would cause time to display as HH:M instead of HH:MM)
                    text2 = "0" + text2;
                }
                if (intTime > 12)
                {
                    //This is for AM/PM time rather than 24hour time
                    intTime -= 12;
                }
                if (intTime == 0)
                {
                    //0AM = 12AM
                    intTime = 12;
                }
                //Whack it all together to get a HH:MM format
                var newText = string.Concat("Time: ", intTime, ":", text2, " ", text);
                Main.NewText(newText, 255, 240, 20);
            }
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            n--;
            if (n == -10)
            {
                n = -10;
            }
            if (can)
            {
                if (m == 0)
                {
                    Tile tile = Main.tile[i, j];
                    // Vector2 spawnPosition;
                    spawnPosition = new Vector2(i * 16 + 16, j * 16 + 26);
                    spawnPosition2 = new Vector2(i * 16, j * 16 + 16);
                }
                m++;
                if (m == 2)
                {
                    m = 1;
                }
                Lighting.AddLight(spawnPosition, 1.5f, 1.5f, 0f);
                if (k >= 2990)
                {
                    Dust.NewDustDirect(spawnPosition2, 30, 30, DustID.GoldFlame);
                    Dust.NewDustDirect(spawnPosition2, 30, 30, DustID.GoldFlame);
                    Dust.NewDustDirect(spawnPosition2, 30, 30, DustID.GoldFlame);
                }
                if (closer)
                {
                    t++;
                    if (t > 60)
                    {
                        t = 0;
                    }
                    // Tile tile = Main.tile[i, j];
                    float distanceMax = 600f;
                    // Vector2 spawnPosition;
                    // spawnPosition = new Vector2(i * 16, j * 16);
                    NPC target = null;

                    Main.clock = true;
                    foreach (NPC npc in Main.npc)
                    {
                        if (npc.active && npc.type != NPCID.TargetDummy && !npc.friendly && Collision.CanHit(spawnPosition, 1, 1, npc.position, npc.width, npc.height))
                        {
                            float currentDistance = Vector2.Distance(npc.Center, spawnPosition);
                            if (currentDistance < distanceMax)
                            {
                                // 就把最大距离设置为npc和玩家的距离
                                // 并且暂时选取这个npc为距离最近npc
                                distanceMax = currentDistance;
                                target = npc;
                            }
                        }
                    }
                    // float baseRot = 0.15f;
                    // 如果找到符合条件的npc， 并且符合开火间隔（一秒10次）
                    if (target != null && t % 3 == 0)
                    {
                        if (n > 0)
                        {
                            k++;
                            if (k <= 100)
                            {
                                pow = 2;
                            }
                            if (k == 200)
                            {
                                pow = 3;
                            }
                            if (k == 300)
                            {
                                pow = 4;
                            }
                            if (k == 400)
                            {
                                pow = 5;
                            }
                            if (k == 500)
                            {
                                pow = 6;
                            }
                            if (k == 600)
                            {
                                pow = 7;
                            }
                            if (k == 700)
                            {
                                pow = 8;
                            }
                            if (k == 800)
                            {
                                pow = 9;
                            }
                            if (k == 900)
                            {
                                pow = 10;
                            }
                            if (k == 1500)
                            {
                                pow = 15;
                                // Main.NewText(k);
                            }
                            if (k == 2000)
                            {
                                pow = 20;
                                // Main.NewText(k);
                            }
                            if (k == 3000)
                            {
                                pow = 25;
                                // Main.NewText(k);
                                Lighting.AddLight(target.position, 1.0f, 1.0f, 1.0f);
                                Dust dust = Dust.NewDustDirect(target.position, target.width, target.height, DustID.Fire);
                                dust.noGravity = true;
                                dust.scale = 1.6f;
                                Dust dust2 = Dust.NewDustDirect(target.position, target.width, target.height, DustID.Fire);
                                dust2.noGravity = true;
                                dust2.scale = 1.6f;
                                Dust dust3 = Dust.NewDustDirect(target.position, target.width, target.height, DustID.Fire);
                                dust3.noGravity = true;
                                dust3.scale = 1.6f;
                            }
                            if (k > 3000)
                            {
                                // Lighting.AddLight(spawnPosition, 1.5f, 1.5f, 0f);
                                k = 2999;
                            }
                        }
                        else
                        {
                            k = 0;
                        }
                        Vector2 toTarget = target.Center - spawnPosition;
                        toTarget.Normalize();
                        toTarget *= 10f;
                        // toTarget = toTarget.RotatedBy(baseRot);
                        if (pow < 20)
                        {
                            // mod.ProjectileType("laser1")
                            Projectile.NewProjectile(spawnPosition,
                                          toTarget, ProjectileID.MagnetSphereBolt, 2 * pow, 0f, Main.myPlayer);

                        }
                        if (pow == 20)
                        {
                            Projectile.NewProjectile(spawnPosition,
                                          toTarget, ProjectileID.MagnetSphereBolt, 2 * pow, 1f, Main.myPlayer);

                        }
                        if (pow > 20)
                        {
                            Projectile.NewProjectile(spawnPosition,
                                          toTarget, ProjectileID.MagnetSphereBolt, 2 * pow, 2f, Main.myPlayer);

                        }
                        n = 300;
                    }
                }
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 32, mod.ItemType("Lasermach"));
        }
    }
}
