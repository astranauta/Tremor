using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class PlagueSoul : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plague Soul");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 24;
			npc.damage = 41;
			npc.defense = 30;
			npc.lifeMax = 125;
			npc.HitSound = SoundID.NPCHit52;
			npc.DeathSound = SoundID.NPCDeath55;
			npc.knockBackResist = 0f;
			aiType = 472;
			npc.noGravity = true;
			npc.aiStyle = 86;
			animationType = 472;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
			}
			else
			{

				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 27, (float)hitDirection, -2f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, (float)hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

	}
}