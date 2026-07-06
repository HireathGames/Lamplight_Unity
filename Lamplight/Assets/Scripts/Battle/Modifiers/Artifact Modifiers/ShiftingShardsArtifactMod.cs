using UnityEngine;

public class ShiftingShardsArtifactMod : CombatModifier
{
    private bool[] types;
    public override void playedCard(Player player, Card card)
    {
        base.playedCard(player, card);
        if (types == null)
        {
            types = new bool[4];
        }
        if (card.getType() == 'w')
        {
            types[0] = true;
        }
        else if (card.getType() == 'm')
        {
            types[1] = true;
        }
        else if (card.getType() == 't')
        {
            types[2] = true;
        }
        else if (card.getType() == 'b')
        {
            types[3] = true;
        }
        if (types[0] && types[1] && types[2] && types[3])
        {
            player.regeneration += 6;
            player.healthBar.updateUI(player);
            makeDone();
        }
    }
}
