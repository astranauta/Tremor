using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AlchemistSpark : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;


			item.rare = 1;
			item.accessory = true;
			item.value = 20000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Spark");
			Tooltip.SetDefault("3% increased alchemic damage\nIncreases alchemic critical strike chance by 8");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.03f;
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AdventurerSpark");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
