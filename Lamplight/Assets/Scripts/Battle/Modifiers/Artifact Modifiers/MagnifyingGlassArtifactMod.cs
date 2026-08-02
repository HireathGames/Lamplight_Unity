using UnityEngine;
[System.Serializable]
public class MagnifyingGlassArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        if (player.weakness > 0)
        {
            player.weakness--;
        }
    }
}
