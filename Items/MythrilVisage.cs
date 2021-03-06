using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class MythrilVisage : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 26;

			item.value = 400;
			item.rare = 4;
			item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mythril Visage");
			Tooltip.SetDefault("Increases alchemic damage by 20%");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.20f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 379 && legs.type == 380;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases alchemic critical strike chance by 16%";
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 16;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilBar, 10);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
