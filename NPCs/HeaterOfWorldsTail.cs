using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class HeaterOfWorldsTail : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heater of Worlds");
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 6500;
			npc.damage = 39;
			npc.defense = 40;
			npc.width = 30;
			npc.height = 62;
			npc.noTileCollide = true;
			npc.behindTiles = true;
			npc.friendly = false;
			npc.noGravity = true;
			npc.aiStyle = 6;
			npc.dontCountMe = true;
			npc.lavaImmune = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[67] = true;
			npc.npcSlots = 5f;
			music = 17;
			npc.dontTakeDamage = true;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath10;
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.expertMode || Main.rand.Next(1) == 0)
			{
				player.AddBuff(24, 180, true);
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}
		public override void AI()
		{
			if (!Main.npc[(int)npc.ai[1]].active)
			{
				npc.life = 0;
				npc.HitEffect(0, 10.0);
				npc.active = false;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);

			Vector2 drawPos = new Vector2(
				npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
				npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);

			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);

			return false;
		}
	}
}