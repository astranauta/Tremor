using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{

	public class Corpse1 : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corpse");
			Main.npcFrameCount[npc.type] = 9;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 80;
        npc.damage = 60;
        npc.defense = 20;
        npc.knockBackResist = 0.3f;
        npc.width = 34;
        npc.height = 34;
        animationType = 462;
        aiType = 462;
        npc.aiStyle = 3;
        npc.npcSlots = 0.2f;
        npc.HitSound = SoundID.NPCHit1;
        npc.DeathSound = SoundID.NPCDeath2;
        npc.value = Item.buyPrice(0, 0, 8, 7);
        banner = npc.type;
        bannerItem = mod.ItemType("LittleCorpseBanner");
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CorpseGore1"), 0.8f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CorpseGore2"), 0.8f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CorpseGore2"), 0.8f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CorpseGore3"), 0.8f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CorpseGore3"), 0.8f);
        }
}

}}