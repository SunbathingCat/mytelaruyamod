using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Weapons
{
    public class zombiekiller : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("jsss");
            Tooltip.SetDefault("僵尸杀手");
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 1.2f;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.type==NPCID.Zombie||target.type==NPCID.ZombieDoctor||target.type==NPCID.ZombieElf || target.type == NPCID.ZombieElfBeard || target.type == NPCID.ZombieElfGirl || target.type == NPCID.ZombieEskimo || target.type == NPCID.ZombieMushroom || target.type == NPCID.ZombieMushroomHat || target.type == NPCID.ZombiePixie || target.type == NPCID.ZombieRaincoat || target.type == NPCID.ZombieSuperman || target.type == NPCID.ZombieSweater || target.type == NPCID.ZombieXmas || target.type == NPCID.ArmedZombie || target.type == NPCID.TwiggyZombie || target.type == NPCID.SwampZombie || target.type == NPCID.SmallZombie || target.type == NPCID.SmallTwiggyZombie || target.type == NPCID.SmallSwampZombie || target.type == NPCID.SmallSlimedZombie || target.type == NPCID.SmallRainZombie || target.type == NPCID.SmallPincushionZombie || target.type == NPCID.SmallFemaleZombie || target.type == NPCID.SmallBaldZombie || target.type == NPCID.SlimedZombie || target.type == NPCID.ArmedZombieTwiggy || target.type == NPCID.PincushionZombie || target.type == NPCID.BigZombie || target.type == NPCID.BloodZombie || target.type == NPCID.BigZombie || target.type == NPCID.BigTwiggyZombie || target.type == NPCID.BigSwampZombie || target.type == NPCID.BigSlimedZombie || target.type == NPCID.BigRainZombie || target.type == NPCID.BigPincushionZombie || target.type == NPCID.BigFemaleZombie || target.type == NPCID.BigBaldZombie || target.type == NPCID.BaldZombie || target.type == NPCID.ArmedZombieTwiggy || target.type == NPCID.ArmedZombieSwamp || target.type == NPCID.ArmedZombieSlimed || target.type == NPCID.ArmedZombiePincussion || target.type == NPCID.ArmedZombieEskimo || target.type == NPCID.ArmedZombieCenx)
            {
                // target.realLife -= 100;
                // target.life -= 100;
                player.ApplyDamageToNPC(target, 20, 5,player.direction,Main.rand.Next(6)==2);
            }
        }
        public override void HoldItem(Player player)
        {

            
            NPC tar = null;
            float distanceMax = 1000f;
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && (npc.type == NPCID.Zombie || npc.type == NPCID.ZombieDoctor || npc.type == NPCID.ZombieElf || npc.type == NPCID.ZombieElfBeard || npc.type == NPCID.ZombieElfGirl || npc.type == NPCID.ZombieEskimo || npc.type == NPCID.ZombieMushroom || npc.type == NPCID.ZombieMushroomHat || npc.type == NPCID.ZombiePixie || npc.type == NPCID.ZombieRaincoat || npc.type == NPCID.ZombieSuperman || npc.type == NPCID.ZombieSweater || npc.type == NPCID.ZombieXmas || npc.type == NPCID.ArmedZombie || npc.type == NPCID.TwiggyZombie || npc.type == NPCID.SwampZombie || npc.type == NPCID.SmallZombie || npc.type == NPCID.SmallTwiggyZombie || npc.type == NPCID.SmallSwampZombie || npc.type == NPCID.SmallSlimedZombie || npc.type == NPCID.SmallRainZombie || npc.type == NPCID.SmallPincushionZombie || npc.type == NPCID.SmallFemaleZombie || npc.type == NPCID.SmallBaldZombie || npc.type == NPCID.SlimedZombie || npc.type == NPCID.ArmedZombieTwiggy || npc.type == NPCID.PincushionZombie || npc.type == NPCID.BigZombie || npc.type == NPCID.BloodZombie || npc.type == NPCID.BigZombie || npc.type == NPCID.BigTwiggyZombie || npc.type == NPCID.BigSwampZombie || npc.type == NPCID.BigSlimedZombie || npc.type == NPCID.BigRainZombie || npc.type == NPCID.BigPincushionZombie || npc.type == NPCID.BigFemaleZombie || npc.type == NPCID.BigBaldZombie || npc.type == NPCID.BaldZombie || npc.type == NPCID.ArmedZombieTwiggy || npc.type == NPCID.ArmedZombieSwamp || npc.type == NPCID.ArmedZombieSlimed || npc.type == NPCID.ArmedZombiePincussion || npc.type == NPCID.ArmedZombieEskimo || npc.type == NPCID.ArmedZombieCenx))
                {
                    float currentDistance = Vector2.Distance(npc.Center, player.Center);
                    if (currentDistance < distanceMax)
                    {
                        // distanceMax = currentDistance;
                        tar = npc;
                        Lighting.AddLight(tar.position, 1.0f, 1.0f, 1.0f);
                    }
                }
            }
            // base.HoldItem(player);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
