using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class StardustSquidBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Stardust Squid");
			Description.SetDefault("A stardust squid is following you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			modPlayer.stardustSquid = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("StardustSquid")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("StardustSquid"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}