﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace Tremor.NovaPillar
{
	public class NovaSky : CustomSky
	{
		private struct Star
		{
			public Vector2 Position;
			public float Depth;
			public int TextureIndex;
			public float SinOffset;
			public float AlphaFrequency;
			public float AlphaAmplitude;
		}
		private NovaSky.Star[] _stars;
		private Random _random = new Random();
		public static Texture2D PlanetTexture;
		private Texture2D[] _starTextures;
		public static Texture2D BGTexture;
		bool Active = false;
		float Intensity = 0f;

		public override void Update(GameTime gameTime)
		{
			if (Active)
			{
				Intensity = Math.Min(1f, 0.01f + Intensity);
				return;
			}
			Intensity = Math.Max(0f, Intensity - 0.01f);
		}

		public override void OnLoad()
		{
			this._starTextures = new Texture2D[3];
			for (int i = 0; i < this._starTextures.Length; i++)
			{
				this._starTextures[i] = ModLoader.GetMod("Tremor").GetTexture("NovaPillar/NovaSoul " + i);
			}
		}

		public override Color OnTileColor(Color inColor)
		{
			Vector4 value = inColor.ToVector4();
			return new Color(Vector4.Lerp(value, Vector4.One, Intensity * 0.5f));
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 3.40282347E+38f && minDepth < 3.40282347E+38f)
			{
				for (int i = 0; i < 200; i++)
				{
					var rect = new Rectangle(0, (int)Math.Ceiling(Main.screenHeight / 200f) * i, Main.screenWidth, (int)Math.Ceiling(Main.screenHeight / 200f));
					var color = Color.Lerp(Color.Black, Color.Yellow, i / 200f) * Intensity;
					spriteBatch.Draw(Main.blackTileTexture, rect, color);
				}
				var planetPos = new Vector2(Main.screenWidth * 0.3f, Main.screenHeight * 0.3f);
				spriteBatch.Draw(PlanetTexture, planetPos, null, Color.White * 0.9f * Intensity, 0f, PlanetTexture.Size() / 2, 0.4f, 0, 0);
			}
			int num = -1;
			int num2 = 0;
			for (int i = 0; i < this._stars.Length; i++)
			{
				float depth = this._stars[i].Depth;
				if (num == -1 && depth < maxDepth)
				{
					num = i;
				}
				if (depth <= minDepth)
				{
					break;
				}
				num2 = i;
			}
			if (num == -1)
			{
				return;
			}
			float scale = Math.Min(1f, (Main.screenPosition.Y - 1000f) / 1000f);
			Vector2 value3 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int j = num; j < num2; j++)
			{
				Vector2 value4 = new Vector2(1f / this._stars[j].Depth, 1.1f / this._stars[j].Depth);
				Vector2 position = (this._stars[j].Position - value3) * value4 + value3 - Main.screenPosition;
				if (rectangle.Contains((int)position.X, (int)position.Y))
				{
					float num3 = (float)Math.Sin((double)(this._stars[j].AlphaFrequency * Main.GlobalTime + this._stars[j].SinOffset)) * this._stars[j].AlphaAmplitude + this._stars[j].AlphaAmplitude;
					float num4 = (float)Math.Sin((double)(this._stars[j].AlphaFrequency * Main.GlobalTime * 5f + this._stars[j].SinOffset)) * 0.1f - 0.1f;
					num3 = MathHelper.Clamp(num3, 0f, 1f);
					Texture2D texture2D = this._starTextures[this._stars[j].TextureIndex];
					spriteBatch.Draw(texture2D, position, null, Color.White * scale * num3 * 0.8f * (1f - num4) * Intensity, 0f, new Vector2((float)(texture2D.Width >> 1), (float)(texture2D.Height >> 1)), (value4.X * 0.5f + 0.5f) * (num3 * 0.3f + 0.7f), SpriteEffects.None, 0f);
				}
			}
		}

		public override float GetCloudAlpha()
		{
			return 1f - Intensity;
		}

		public override void Activate(Vector2 position, params object[] args)
		{
			int num = 200;
			int num2 = 10;
			this._stars = new NovaSky.Star[num * num2];
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				float num4 = (float)i / (float)num;
				for (int j = 0; j < num2; j++)
				{
					float num5 = (float)j / (float)num2;
					this._stars[num3].Position.X = num4 * (float)Main.maxTilesX * 16f;
					this._stars[num3].Position.Y = num5 * ((float)Main.worldSurface * 16f + 2000f) - 1000f;
					this._stars[num3].Depth = Main.rand.NextFloat() * 8f + 1.5f;
					this._stars[num3].TextureIndex = Main.rand.Next(this._starTextures.Length);
					this._stars[num3].SinOffset = Main.rand.NextFloat() * 6.28f;
					this._stars[num3].AlphaAmplitude = Main.rand.NextFloat() * 5f;
					this._stars[num3].AlphaFrequency = Main.rand.NextFloat() + 1f;
					num3++;
				}
			}
			Array.Sort<NovaSky.Star>(this._stars, new Comparison<NovaSky.Star>(this.SortMethod));

			Active = true;
		}

		private int SortMethod(NovaSky.Star meteor1, NovaSky.Star meteor2)
		{
			return meteor2.Depth.CompareTo(meteor1.Depth);
		}

		public override void Deactivate(params object[] args)
		{
			Active = false;
		}

		public override void Reset()
		{
			Active = false;
		}

		public override bool IsActive()
		{
			return Active || Intensity > 0f;
		}
	}
}
