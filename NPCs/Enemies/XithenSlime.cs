﻿using SophmoreProject.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SophmoreProject.Internal;
using SophmoreProject.NPCs.Common;

namespace SophmoreProject.NPCs.Enemies
{

	// HEY UM SLIME HAS SOME WHITE STUFF ON A FRAME HAVE FUIN
	public class XithenSlime : ModNPC
	{


		float spawnCoeffcient = .2f;
		

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xithen Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 28;
			npc.damage = 29;
			npc.lifeMax = 120; // 120
			npc.life = 120;
			npc.defense = 5;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 100f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			aiType = NPCID.BlueSlime;
			animationType = NPCID.BlueSlime;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldDaySlime.Chance * spawnCoeffcient; // .2
		}

		public override bool PreAI()
		{
			npc.TargetClosest(true);
			return true;
		}

		public override void AI()
        {
			if (Main.rand.Next(0, 100) <= 1)
			{
				CommonNpcFunctions.ShootXithenProjectile(npc);
			}
			//base.AI();
		}

        public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.Xithricite>(), Main.rand.Next(1, 3));
		}
	}
}