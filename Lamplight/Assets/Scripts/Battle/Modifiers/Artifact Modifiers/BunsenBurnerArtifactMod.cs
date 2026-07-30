using UnityEngine;
[System.Serializable]
public class BunsenBurnerArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        foreach (Enemy e in player.manager.getEnemies())
        {
            e.takeDamage(0, 5, 'n');
        }
    }
}
