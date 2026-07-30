using UnityEngine;
[System.Serializable]
public class HarkersJournalArtifactMod : CombatModifier
{
    public override void playerTurnEnd(Player player)
    {
        int bleed = 0;
        foreach (Enemy e in player.manager.getEnemies())
        {
            bleed += e.bleed;
        }
        player.addArmor(bleed/3);
    }
}
