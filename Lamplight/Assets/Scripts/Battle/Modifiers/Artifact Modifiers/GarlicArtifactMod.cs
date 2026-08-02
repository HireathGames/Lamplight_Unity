using UnityEngine;
[System.Serializable]
public class GarlicArtifactMod : CombatModifier
{
    public override void playerTurnEnd(Player player)
    {
        if (player.bleed > 2)
        {
            player.bleed -= 2;
        }
        else
        {
            player.bleed = 0;
        }
    }
}
