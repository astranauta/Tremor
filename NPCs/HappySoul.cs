using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Tremor.NPCs
{
	[AutoloadBossHead]

	public class HappySoul : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Happiness");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 750;
			npc.damage = 26;
			npc.defense = 5;
			npc.knockBackResist = 1f;
			npc.width = 60;
			npc.height = 85;
			animationType = 288;
			npc.aiStyle = 17;
			npc.npcSlots = 15f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit31;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 2, 0, 9);
		}
		public override void AI()
		{
			npc.position += npc.velocity * 2f;
			if (Main.rand.Next(6) == 0)
			{
				int num706 = Dust.NewDust(npc.position, npc.width, npc.height, 62, 0f, 0f, 200, npc.color, 1f);
				Main.dust[num706].velocity *= 0.3f;
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 62, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 62, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 62, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 62, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 62, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 62, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 62, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.6f);
					Dust.NewDust(npc.position, npc.width, npc.height, 62, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 62, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}
	}
}