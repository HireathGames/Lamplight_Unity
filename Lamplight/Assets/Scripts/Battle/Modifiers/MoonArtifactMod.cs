using UnityEngine;

public class MoonArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        foreach (Enemy e in player.manager.getEnemies())
        {
            e.weakness++;
            e.healthBar.updateUI(e);
        }
        makeDone();
    }
}
