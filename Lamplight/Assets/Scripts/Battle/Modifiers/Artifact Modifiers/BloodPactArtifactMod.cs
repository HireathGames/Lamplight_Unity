using UnityEngine;

public class BloodPactArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        player.strength += 3;
        player.bleed += 3;
        player.healthBar.updateUI(player);
        makeDone();
    }
}
