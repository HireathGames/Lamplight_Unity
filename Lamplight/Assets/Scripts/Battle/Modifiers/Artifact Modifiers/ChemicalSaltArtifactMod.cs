using UnityEngine;

public class ChemicalSaltArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        foreach (Enemy e in player.manager.getEnemies())
        {
            e.broken += 6;
        }
        makeDone();
    }
}
