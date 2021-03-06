using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Waters
{
	public class IceWater : ModWaterStyle
	{
        public override bool ChooseWaterStyle()
        {
            Mod mod = ModLoader.GetMod("Tremor");
            TremorPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<TremorPlayer>(mod);
            return modPlayer.ZoneIce;
        }

        public override int ChooseWaterfallStyle()
		{
			return mod.GetWaterfallStyleSlot("IceWaterfall");
		}

		public override int GetSplashDust()
		{
			return mod.DustType("IceWaterSplash");
		}

		public override int GetDropletGore()
		{
			return mod.GetGoreSlot("Gores/IceDroplet");
		}

		public override void LightColorMultiplier(ref float r, ref float g, ref float b)
		{
			r = 1f;
			g = 1f;
			b = 1f;
		}

		public override Color BiomeHairColor()
		{
			return Color.White;
		}
	}
}