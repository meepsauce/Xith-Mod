﻿using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using SophmoreProject.Internal;

namespace SophmoreProject.Items.Materials
{
	public class Xithricite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xithricite");
			Tooltip.SetDefault("A super-dense crystalline metal");
		}

		public override void SetDefaults()
		{
			item.maxStack = 99;                 //this is where you set the max stack of item
			item.consumable = false;           //this make that the item is consumable when used
			item.width = 8;
			item.height = 8;
			item.value = 400;
			item.rare = ItemRarityID.Blue;
			
		}

		public override void PostUpdate()
		{
			Lighting.AddLight(item.Center, new Vector3(Palette.lightColor.R, Palette.lightColor.G, Palette.lightColor.B) * .005f);
		}

	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.XithenOreItem>(), 3);
			recipe.AddTile(ItemID.Furnace);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}