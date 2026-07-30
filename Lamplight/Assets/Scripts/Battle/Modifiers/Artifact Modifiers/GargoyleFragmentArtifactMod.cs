using UnityEngine;
[System.Serializable]
public class GargoyleFragmentArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        foreach (Enemy e in player.manager.getEnemies())
        {
            e.decreaseBrokenRatio(2);
        }
        makeDone();
    }
}
