using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar
{
	public class NovaAlchemist : ModNPC
	{

		//Int variables
		int AnimationRate = 8;
		int CountFrame = 0;
		int TimeToAnimation = 8;
		int Timer = 0;

		//Bool variables
		bool TimeToPortals = false;
		public override void SetDefaults()
		{
			npc.lifeMax = 2500;
			npc.damage = 100;
			npc.defense = 25;
			npc.knockBackResist = 0.4f;
			npc.width = 34;
			npc.height = 56;
			npc.aiStyle = 3;
			aiType = NPCID.AngryBones;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit55;
			npc.DeathSound = SoundID.NPCDeath51;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Alchemist");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
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
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/NovaAlchemistGore3"));
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/NovaAlchemistGore4"));
				}
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/NovaAlchemistGore2"));
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/NovaAlchemistGore1"));
			}
		}

		public override void AI()
		{
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			if (Main.rand.Next(800) == 0)
			{
				Main.PlaySound(SoundID.NPCDeath51, npc.Center);
			}
			this.Timer++;
			this.NovaAnimation();
			if (this.Timer >= 600)
			{
				this.TimeToPortals = true;
			}
			if (this.Timer >= 600 && this.Timer % 200 == 0)
			{
				if (Main.netMode != 1)
				{
					Main.PlaySound(SoundID.NPCDeath55, npc.Center);
					NPC.NewNPC((int)npc.Center.X + 25, (int)npc.Center.Y, mod.NPCType("NovaAlchemistC"));
					NPC.NewNPC((int)npc.Center.X - 25, (int)npc.Center.Y, mod.NPCType("NovaAlchemistC"));
				}
			}
			if (this.Timer < 600)
			{
				this.TimeToPortals = false;
			}
			if (this.Timer >= 800)
			{
				this.Timer = 0;
			}
			if (this.TimeToPortals)
			{
				npc.velocity.X = 0f;
				npc.velocity.Y += 5f;
			}
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			TremorUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NovaPillar/NovaAlchemist_GlowMask"));
		}

		public void NovaAnimation()
		{
			if (!this.TimeToPortals)
			{
				if (--this.TimeToAnimation <= 0)
				{
					if (++this.CountFrame > 3)
						this.CountFrame = 1;
					this.TimeToAnimation = this.AnimationRate;
					npc.frame = this.GetFrame(this.CountFrame);
				}
			}
			else
				npc.frame = this.GetFrame(4);
		}

		Rectangle GetFrame(int Num)
		{
			return new Rectangle(0, npc.frame.Height * (Num - 1), npc.frame.Width, npc.frame.Height);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.GetModPlayer<TremorPlayer>(mod).ZoneTowerNova)
				return 1f;
			return 0;
		}
	}
}