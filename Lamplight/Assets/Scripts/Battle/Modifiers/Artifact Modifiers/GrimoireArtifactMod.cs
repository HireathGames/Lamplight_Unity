using UnityEngine;

public class GrimoireArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        player.setSanity(player.getSanity() + 10);
        if (player.getSanity() > 100f)
        {
            player.setSanity(100f);
        }
        makeDone();
    }
}
