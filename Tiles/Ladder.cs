using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles
{
	public class Ladder : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.CoordinateHeights = new int[]{16};
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.addTile(Type);
	AddMapEntry(new Color(13, 88, 130));
        Main.tileSolid[Type] = true;
    }

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("Ladder"));
		}

}}