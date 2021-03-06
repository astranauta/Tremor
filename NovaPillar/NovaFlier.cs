﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar
{
	public class NovaFlier : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Flier");
			Main.npcFrameCount[npc.type] = 4;
		}

		//Int variables
		int AnimationRate = 4;
		int CountFrame = 0;
		int TimeToAnimation = 4;
		int Timer = 0;

		//Vanilla AI
		static int num1461 = 360;
		float num1453 = 7f;
		float num1463 = 6.28318548f / (float)(num1461 / 2);
		int num1450 = 200;
		int num1472 = 0;
		bool flag128;
		static float scaleFactor10 = 8.5f;
		float num1451 = 0.55f;
		public override void SetDefaults()
		{
			npc.lifeMax = 2150;
			npc.damage = 67;
			npc.defense = 15;
			npc.knockBackResist = 0.2f;
			npc.width = 44;
			npc.height = 56;
			npc.HitSound = SoundID.NPCHit55;
			npc.DeathSound = SoundID.NPCDeath51;
			npc.buffImmune[31] = false;
			npc.npcSlots = 2f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = false;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void AI()
		{
			npc.spriteDirection = npc.direction;
			this.NovaAnimation();
			if (Main.time % 200 == 0)
			{
				Vector2 Velocity = Helper.VelocityToPoint(npc.Center, Helper.RandomPointInArea(new Vector2(Main.player[Main.myPlayer].Center.X - 10, Main.player[Main.myPlayer].Center.Y - 10), new Vector2(Main.player[Main.myPlayer].Center.X + 20, Main.player[Main.myPlayer].Center.Y + 20)), 7);
				int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("NovaFlierProj"), 20, 1f);
			}
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			TremorUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NovaPillar/NovaFlier_GlowMask"));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				if (NovaHandler.ShieldStrength > 0)
				{
					NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("NovaPillar"))];
					Vector2 Velocity = Helper.VelocityToPoint(npc.Center, parent.Center, 20);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("CogLordLaser"), 1, 1f);
				}
				for (int i = 0; i < 5; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
				}
				for (int i = 0; i < 2; i++)
				{
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/NovaFlierGore1"));
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/NovaFlierGore2"));
				}
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/NovaFlierGore3"));
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/NovaFlierGore3"));
			}
		}

		void NovaAnimation()
		{
			if (--this.TimeToAnimation <= 0)
			{
				if (++this.CountFrame > 4)
					this.CountFrame = 1;
				this.TimeToAnimation = this.AnimationRate;
				npc.frame = this.GetFrame(this.CountFrame + 0);
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.GetModPlayer<TremorPlayer>(mod).ZoneTowerNova)
				return 1f;
			return 0;
		}
	}
}
