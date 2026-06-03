using UnityEngine;

public class SunArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        player.strength += 1;
        player.healthBar.updateUI(player);
        makeDone();
    }
}
