using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class PlagueHelmet : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 25000;
			item.rare = 2;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plague Helmet");
			Tooltip.SetDefault("Increases alchemic damage by 10%");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("PlagueBreastplate") && legs.type == mod.ItemType("PlagueGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases size of alchemic clouds";
			player.AddBuff(mod.BuffType("FlaskExpansionBuff"), 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 12);
			recipe.AddIngredient(null, "PhantomSoul", 4);
			recipe.AddIngredient(null, "TearsofDeath", 8);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

	}
}
