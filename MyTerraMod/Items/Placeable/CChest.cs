using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Placeable
{
    public class CChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("C型宝箱");
            Tooltip.SetDefault("需要C型密钥才能打开");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 10000;
            item.createTile = mod.TileType("CChest");
        }
    }
}
