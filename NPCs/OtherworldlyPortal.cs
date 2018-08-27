using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.NPCs
{
	public class OtherworldlyPortal : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Otherworldly Portal");
            DisplayName.AddTranslation(GameCulture.Chinese, "异界传送门");
		}

		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.BoundMechanic);
			npc.townNPC = true;
			npc.width = 54;
			npc.height = 100;
			npc.damage = 1;
			npc.defense = 500;
			npc.lifeMax = 500;
			npc.knockBackResist = 0.1f;
			npc.noGravity = true;
			npc.rarity = 5;
		}
		
		public override string GetChat()
		{
			return Language.GetTextValue("Mods.AlchemistNPC.portalOpen");
		}
		
		public override void AI()
        {
			Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			if (Main.rand.Next(2) == 0)
			{
				for (int i = 0; i < 10; i++)
				{
					int dustType = Main.rand.Next(51, 54);
					int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 0.95f;
					dust.noGravity = true;
				}
			}
            if (npc.aiStyle == 0)
            {
                for (int index = 0; index < (int)byte.MaxValue; ++index)
                {
                    if (Main.player[index].active && Main.player[index].talkNPC == npc.whoAmI)
                    {
						string barrierStabilized = Language.GetTextValue("Mods.AlchemistNPC.barrierStabilized");
                        Main.NewText(barrierStabilized, 55, 55, 255);
						npc.Transform(mod.NPCType("Explorer"));
						return;
					}
				}
			}
		}
	}
}
