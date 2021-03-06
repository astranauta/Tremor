﻿using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace Tremor.Projectiles
{
    public class TrueBladeTwo : ModProjectile
    {
        const float RotationSpeed = 0.05f;
        const float Distanse = 100;

        float Rotation = 0;

        public override void SetDefaults()
        {

            projectile.width = 22;
            projectile.height = 44;
            projectile.timeLeft = 6;
            projectile.melee = true;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("True Blade");
       
    }


		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
        public override void AI()
        {
            Rotation += RotationSpeed;
            projectile.Center = Helper.PolarPos(Main.LocalPlayer.Center, Distanse, Helper.GradtoRad(Rotation));
            projectile.rotation = Helper.rotateBetween2Points(Main.LocalPlayer.Center, projectile.Center) - Helper.GradtoRad(90);
        }

        public override bool? CanHitNPC(NPC target)
        {
            return !target.friendly;
        }
    }
}
