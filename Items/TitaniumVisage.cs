using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class TitaniumVisage : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 24;

			item.value = 400;
			item.rare = 4;
			item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanium Visage");
			Tooltip.SetDefault("Increases alchemic damage by 24%");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.24f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1218 && legs.type == 1219;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases alchemic critical strike chance by 20% and become invulnerable after striking an enemy";
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 20;
			player.onHitDodge = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
