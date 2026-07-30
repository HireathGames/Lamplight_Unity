using UnityEngine;
[System.Serializable]
public class DamnedShacklesArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        foreach (Enemy e in player.manager.getEnemies())
        {
            if (e.strength > 0)
            {
                e.strength--;
            }
        }
    }
}
