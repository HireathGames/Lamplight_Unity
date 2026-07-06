using UnityEngine;

public class SacredBloodArtifactMod : CombatModifier
{
    public override void playerCombatEnd(Player player)
    {
        base.playerTurnStart(player);
        player.manager.getRun().maxHP += 3;
        player.manager.getRun().HP += 3;
        makeDone();
    }
}
