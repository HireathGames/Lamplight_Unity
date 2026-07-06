using UnityEngine;

public class RedMaskArtifactMod : CombatModifier
{
    public override void playedCard(Player player, Card card)
    {
        base.playedCard(player, card);
        if (card is RedDeath)
        {
            foreach (Enemy e in player.manager.getEnemies())
            {
                e.bleed += 3;
                e.healthBar.updateUI(e);
            }
        }
    }
}
