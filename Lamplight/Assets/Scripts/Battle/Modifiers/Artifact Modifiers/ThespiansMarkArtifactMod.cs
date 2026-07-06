using UnityEngine;

public class ThespiansMarkArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        foreach (Enemy e in player.manager.getEnemies())
        {
            e.weakness += 2;
            e.healthBar.updateUI(e);
        }
        player.strength += 2;
        player.healthBar.updateUI(player);
        makeDone();
    }
}
