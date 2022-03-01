﻿using Microsoft.Xna.Framework;
using SophmoreProject.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SophmoreProject.NPCs.Bosses
{
	public class XithenBoss : ModNPC
	{
		public int phase = 0;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xithen Boss");
		}

		public override void SetDefaults()
		{
			npc.width = 252;
			npc.height = 192;
			npc.damage = 80;
			npc.lifeMax = 1000;
			npc.life = 1000;
			npc.defense = 0;
			
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 1000000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 15;
			aiType = NPCID.KingSlime; // switch to blueslime ai maybe
			animationType = NPCID.BlueSlime;
			npc.boss = true;
			Main.npcFrameCount[npc.type] = 2;
		}


		public override bool PreAI()
		{
			npc.TargetClosest(true);
			return true;
		}
		

		public override void AI()
		{
			// DOES NOT WORK WITH MULTIPLAYER

			if(npc.life < npc.lifeMax * .9)
            {
				if(Main.rand.Next(0, 100) <= 2)
                {
					npc.TargetClosest();
					if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
					{
						Vector2 position = npc.Center;
						
						Vector2 targetPosition = Main.player[npc.target].Center;
						Vector2 direction = targetPosition - position;
						direction.Normalize();
						float speed = 10f;
						int type = ModContent.ProjectileType<XithenProjectile>();
						int damage = npc.damage; //If the projectile is hostile, the damage passed into NewProjectile will be applied doubled, and quadrupled if expert mode, so keep that in mind when balancing projectiles
						Projectile.NewProjectile(position, direction * speed, type, damage, 0f);
					}
				}
				
            }


			if(phase == 0)
            {
				Main.NewText("Hi there kiddo", 200, 0, 0);
				phase++;
			}
			//Phases
			if (npc.life < npc.lifeMax * .8 && phase == 1)
			{
				phase++;
				Main.NewText("Ouchie (~80% health)", 200, 0, 0);
			}
			if (npc.life < npc.lifeMax * .6 && phase == 2)
			{
				phase++;
				Main.NewText("Ouchie (~60 health)", 200, 0, 0);
			}
			if (npc.life < npc.lifeMax * .4 && phase == 3)
			{
				phase++;
				Main.NewText("eeeeeeeeeee (~40 health)", 200, 0, 0);
			}
			if (npc.life < npc.lifeMax * .2 && phase == 4 )
			{
				phase++;
				Main.NewText("AAAAAAAAAAAA (~20 health)", 200, 0, 0);
			}
		}

		public override void NPCLoot()
        {
			//do cool liquid stuff (nvm)
        }
	}
}
