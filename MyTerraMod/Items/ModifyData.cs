using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MyTerraMod.Utilss;

namespace MyTerraMod.Items
{
    public class NightsEdge : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.NightsEdge)
            {
                item.damage = 50;
                item.useTime = 20;
                item.useAnimation = 20;
                item.knockBack = 6;
                // item.crit = 6;
                item.autoReuse = true;
            }
        }
        public override void HoldItem(Item item, Player player)
        {
            if (item.type == ItemID.NightsEdge)
            {
                if (Main.dayTime)
                {
                    item.damage = 50;
                    item.scale = 1.2f;
                }
                else
                {
                    item.damage = 70;
                    item.scale = 1.5f;
                }
                Lighting.AddLight(player.position, 0.5f, 0.5f, 1.0f);
                player.AddBuff(BuffID.WaterCandle, 10);
            }
        }
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (item.type == ItemID.NightsEdge)
            {
                int a = Main.rand.Next(3);
                if (a == 0)
                {
                    target.AddBuff(BuffID.Poisoned, 360);
                }
                if (a == 1)
                {
                    target.AddBuff(BuffID.OnFire, 180);
                }
            }
        }
    }
    public class Excalibur : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Excalibur)
            {
                item.damage = 70;
                item.useTime = 24;
                item.useAnimation = 24;
                item.knockBack = 6;
                item.crit = 6;
                item.autoReuse = true;
            }
        }
        public override void HoldItem(Item item, Player player)
        {
            if (item.type == ItemID.Excalibur)
            {
                player.AddBuff(BuffID.Sunflower, 10);
            }
        }
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (item.type == ItemID.Excalibur)
            {
                if (target.boss || target.type == NPCID.EaterofSouls || target.type == NPCID.CorruptBunny || target.type == NPCID.CorruptGoldfish || target.type == NPCID.DevourerBody || target.type == NPCID.DevourerHead || target.type == NPCID.DevourerTail || target.type == NPCID.Corruptor || target.type == NPCID.CorruptPenguin || target.type == NPCID.CorruptSlime || target.type == NPCID.Slimeling || target.type == NPCID.Slimer || target.type == NPCID.Slimer2 || target.type == NPCID.BloodFeeder || target.type == NPCID.DarkMummy || target.type == 98 || target.type == 99 || target.type == 100 || target.type == NPCID.BloodCrawler || target.type == NPCID.CrimsonAxe || target.type == NPCID.CrimsonBunny || target.type == NPCID.CrimsonGoldfish || target.type == NPCID.CrimsonPenguin || target.type == NPCID.FaceMonster || target.type == NPCID.Crimera || target.type == NPCID.Herpling || target.type == NPCID.Crimslime || target.type == NPCID.BloodJelly || target.type == NPCID.Hellbat || target.type == NPCID.LavaSlime || target.type == NPCID.FireImp || target.type == NPCID.Demon || target.type == NPCID.VoodooDemon || target.type == NPCID.BoneSerpentBody || target.type == NPCID.BoneSerpentHead || target.type == NPCID.BoneSerpentTail || target.type == NPCID.Mimic || target.type == NPCID.Lavabat || target.type == NPCID.RedDevil || target.type == NPCID.PossessedArmor || target.type == NPCID.CursedHammer || target.type == NPCID.EnchantedSword || target.type == NPCID.CrimsonAxe)
                {
                    player.ApplyDamageToNPC(target,item.damage/2,5,player.direction, Main.rand.Next(3) == 2);
                }
            }
        }
    }
    public class TrueNightsEdge : GlobalItem
    {
        //NightBeam
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.TrueNightsEdge)
            {
                item.damage = 140;
                item.useTime = 20;
                item.useAnimation = 20;
                item.knockBack = 8;
                // item.crit = 16;
                item.autoReuse = true;
            }
        }
        public override void HoldItem(Item item, Player player)
        {
            if (item.type == ItemID.TrueNightsEdge)
            {
                if (Main.dayTime)
                {
                    item.damage = 140;
                    item.scale = 1.2f;
                }
                else
                {
                    item.damage = 180;
                    item.scale = 1.5f;
                }
                Lighting.AddLight(player.position, 0.5f, 0.5f, 1.0f);
                player.AddBuff(BuffID.WaterCandle, 10);
            }
        }
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (item.type == ItemID.TrueNightsEdge)
            {
                target.AddBuff(BuffID.ShadowFlame, 300);
            }
        }
    }
    public class TrueExcalibur : GlobalItem
    {
        //LightBeam
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.TrueExcalibur)
            {
                item.damage = 120;
                item.knockBack = 8;
                item.crit = 6;
                item.autoReuse = true;
            }
        }
        public override void HoldItem(Item item, Player player)
        {
            if (item.type == ItemID.TrueExcalibur)
            {
                player.AddBuff(BuffID.Sunflower, 10);
            }
        }
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (item.type == ItemID.TrueExcalibur)
            {
                if (target.boss || target.type == NPCID.EaterofSouls || target.type == NPCID.CorruptBunny || target.type == NPCID.CorruptGoldfish || target.type == NPCID.DevourerBody || target.type == NPCID.DevourerHead || target.type == NPCID.DevourerTail || target.type == NPCID.Corruptor || target.type == NPCID.CorruptPenguin || target.type == NPCID.CorruptSlime || target.type == NPCID.Slimeling || target.type == NPCID.Slimer || target.type == NPCID.Slimer2 || target.type == NPCID.BloodFeeder || target.type == NPCID.DarkMummy || target.type == 98 || target.type == 99 || target.type == 100 || target.type == NPCID.BloodCrawler || target.type == NPCID.CrimsonAxe || target.type == NPCID.CrimsonBunny || target.type == NPCID.CrimsonGoldfish || target.type == NPCID.CrimsonPenguin || target.type == NPCID.FaceMonster || target.type == NPCID.Crimera || target.type == NPCID.Herpling || target.type == NPCID.Crimslime || target.type == NPCID.BloodJelly || target.type == NPCID.Hellbat || target.type == NPCID.LavaSlime || target.type == NPCID.FireImp || target.type == NPCID.Demon || target.type == NPCID.VoodooDemon || target.type == NPCID.BoneSerpentBody || target.type == NPCID.BoneSerpentHead || target.type == NPCID.BoneSerpentTail || target.type == NPCID.Mimic || target.type == NPCID.Lavabat || target.type == NPCID.RedDevil || target.type == NPCID.PossessedArmor || target.type == NPCID.CursedHammer || target.type == NPCID.EnchantedSword || target.type == NPCID.CrimsonAxe)
                {
                    player.ApplyDamageToNPC(target, item.damage / 2, 5, player.direction, Main.rand.Next(3) == 2);
                }
                target.AddBuff(BuffID.CursedInferno, 300);
            }
        }
    }
    public class NightBeam : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.type == ProjectileID.NightBeam)
            {
                projectile.damage = 150;
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.type == ProjectileID.NightBeam)
            {
                target.AddBuff(BuffID.ShadowFlame, 300);
            }
        }
    }
    public class LightBeam : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.type == ProjectileID.LightBeam)
            {
                projectile.damage = 120;
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.type == ProjectileID.LightBeam)
            {
                target.AddBuff(BuffID.CursedInferno, 300);
            }
        }
    }
    public class TerraBlade : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.TerraBlade)
            {
                item.damage = 200;
                // item.useTime = 15;
                // item.useAnimation = 15;
                item.knockBack = 10;
                item.crit = 6;
                item.autoReuse = true;
            }
        }
        public override void HoldItem(Item item, Player player)
        {
            if (item.type == ItemID.TerraBlade)
            {
                Lighting.AddLight(player.position, 1.0f, 1.0f, 0f);
                // player.AddBuff(BuffID.Sunflower, -1);
                player.AddBuff(BuffID.DryadsWard, 10);
            } 
        }
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (item.type == ItemID.TerraBlade)
            {
                //target.AddBuff(BuffID.CursedInferno, 600);
                player.ApplyDamageToNPC(target, target.lifeMax / 200, 5, player.direction, Main.rand.Next(5) == 1);
                target.AddBuff(mod.BuffType("NewCursedInferno"), 600);
            }
        }
    }
    public class PaladinsHammer : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.PaladinsHammer)
            {
                item.autoReuse = true;
            }
        }
    }
    public class PaladinsHammerFriendly : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.type == ProjectileID.PaladinsHammerFriendly)
            {
                projectile.tileCollide = false;
                projectile.penetrate = -1;
            }
        }
    }
    public class TerraBeam : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.type == ProjectileID.TerraBeam)
            {
                projectile.timeLeft = 900;
                projectile.tileCollide = false;
                projectile.penetrate = -1;
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.LocalPlayer;
            if (projectile.type == ProjectileID.TerraBeam)
            {
                player.ApplyDamageToNPC(target, target.lifeMax / 200, 5, player.direction, Main.rand.Next(5) == 1);
                target.AddBuff(mod.BuffType("NewCursedInferno"), 600);
            }
        }
    }
    public class MasterNinja : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ItemID.MasterNinjaGear)
            {
                player.moveSpeed += 0.7f;
                player.endurance += 0.1f;
                player.jumpSpeedBoost += 0.2f;
                // player.jumpBoost = true;
                player.noKnockback = true;
                // player.shroomiteStealth = true;
                player.GetModPlayer<MyPlayer>().stealth = 0.2f;
                player.thrownDamage += 0.2f;
                player.thrownCrit += 10;
                /*for (int i = 0; i < 1; i++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height,
                        MyDustId.PurpleLight, -player.velocity.X * 0.5f, -player.velocity.Y * 0.5f, 100, Color.White, 1.0f);
                }*/
            }
        }
    }
    public class M_Block : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.ClayBlock)
            {
                item.value = Item.buyPrice(0, 0, 0, 10);
            }
            if (item.type == ItemID.DirtBlock)
            {
                // item.value = Item.sellPrice(0, 0, 0, 0);
                item.value = Item.buyPrice(0, 0, 0, 10);
            }
            if (item.type == ItemID.StoneBlock)
            {
                item.value = Item.buyPrice(0, 0, 0, 20);
            }
            if (item.type == ItemID.Wood)
            {
                item.value = Item.buyPrice(0, 0, 0, 50);
            }
            if (item.type == ItemID.MudBlock)
            {
                item.value = Item.buyPrice(0, 0, 0, 20);
            }
            if (item.type == ItemID.SandBlock)
            {
                item.value = Item.buyPrice(0, 0, 0, 50);
            }
            if (item.type == ItemID.SnowBlock)
            {
                item.value = Item.buyPrice(0, 0, 0, 20);
            }
            if (item.type == ItemID.PinkBrick)
            {
                item.value = Item.buyPrice(0, 0, 5, 0);
            }
            if (item.type == ItemID.BlueBrick)
            {
                item.value = Item.buyPrice(0, 0, 5, 0);
            }
            if (item.type == ItemID.GreenBrick)
            {
                item.value = Item.buyPrice(0, 0, 5, 0);
            }
            if (item.type == ItemID.LihzahrdBrick)
            {
                item.value = Item.buyPrice(0, 0, 20, 0);
            }
        }
    }
    public class M_Ore : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.ChlorophyteOre)
            {
                // item.value = Item.sellPrice(0, 0, 0, 0);
                item.value = Item.buyPrice(0, 0, 20, 0);
            }
            if (item.type == ItemID.LunarOre)
            {
                // item.value = Item.sellPrice(0, 0, 0, 0);
                item.value = Item.buyPrice(0, 0, 75, 0);
            }
        }
    }
    public class VampireKnives : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.VampireKnives)
            {
                item.damage = 44;
            }
        }
    }
    public class PiranhaGun : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.PiranhaGun)
            {
                item.damage = 50;
            }
        }
    }
    public class TruffleWorm : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.TruffleWorm)
            {
                item.value = Item.buyPrice(0, 50, 0, 0);
            }
        }
    }
    /*public class CopperShortsword : GlobalItem
    {
        public override bool UseItem(Item item, Player player)
        {
            if (item.type == ItemID.CopperShortsword && player.name == "LG")
            {
                Item.NewItem(player.position, mod.ItemType("SecretKey"), 1);
            }
            return base.UseItem(item, player);
        }
    }*/
}
