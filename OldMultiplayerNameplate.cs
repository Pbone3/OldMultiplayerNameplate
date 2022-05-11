using Terraria;
using Terraria.ModLoader;

namespace OldMultiplayerNameplate
{
	public class OldMultiplayerNameplate : Mod
	{
        public override void Load()
        {
            Main.ActiveClosePlayersTeamOverlay = new OneThreeMultiplayerClosePlayersOverlay();
        }
    }
}