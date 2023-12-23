using System;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ModLoader;

namespace OldMultiplayerNameplate;

public class OldMultiplayerNameplate : Mod {
    private Type _oldNameplateType;

    public override void Load() {
        _oldNameplateType = Main.ActiveClosePlayersTeamOverlay.GetType();
        Main.ActiveClosePlayersTeamOverlay = new OneThreeMultiplayerClosePlayersOverlay();
    }

    public override void Unload() {
        Main.ActiveClosePlayersTeamOverlay = (IMultiplayerClosePlayersOverlay)Activator.CreateInstance(_oldNameplateType);
    }
}