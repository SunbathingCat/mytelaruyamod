using Terraria.ID;
using Terraria.ModLoader;

namespace MyTerraMod.Items.Placeable
{
    public class ADChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("管理员宝箱");
            Tooltip.SetDefault("需要万能密钥才能打开");
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
            item.value = 0;
            item.createTile = mod.TileType("ADChest");
        }
    }
}
