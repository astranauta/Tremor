using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles
{
	public class EvershinyBar : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.CoordinateHeights = new int[]{16};
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.addTile(Type);
	AddMapEntry(new Color(13, 88, 130));
        Main.tileShine[Type] = 1100;
        Main.tileSolid[Type] = true;
    }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("EveryshinyBar"));
            return true;
        }
}}