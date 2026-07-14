using UnityEngine;

public class CrimsonGuestMod : CombatModifier
{
    private Entity self;
    public CrimsonGuestMod(Entity target)
    {
        self = target;
    }
    public override void playedCard(Player player, Card card)
    {
        base.playedCard(player, card);
        if (card is RedDeath)
        {
            self.strength++;
        }
    }
}
