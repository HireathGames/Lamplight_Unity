using UnityEngine;

public class WanterPosterArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        player.strength += 3;
        player.mark += 3;
        makeDone();
    }
}
