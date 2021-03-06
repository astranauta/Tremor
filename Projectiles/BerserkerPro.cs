﻿using Terraria.ModLoader;
using Terraria;

namespace Tremor.Projectiles
{
	public class BerserkerPro : ModProjectile
	{
		const float RotationSpeed = 0.05f;
		const float Distanse = 48;

		float Rotation = 0;

		public override void SetDefaults()
		{

			projectile.width = 18;
			projectile.height = 34;
			projectile.timeLeft = 6;
			projectile.melee = true;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Sword");

		}


		public override void AI()
		{
			Rotation += RotationSpeed;
			projectile.Center = Helper.PolarPos(Terraria.Main.player[(int)projectile.ai[0]].Center, Distanse, Helper.GradtoRad(Rotation));
			projectile.rotation = Helper.rotateBetween2Points(Terraria.Main.player[(int)projectile.ai[0]].Center, projectile.Center) - Helper.GradtoRad(90);
		}

		public override bool? CanHitNPC(NPC target)
		{
			return !target.friendly;
		}
	}
}
