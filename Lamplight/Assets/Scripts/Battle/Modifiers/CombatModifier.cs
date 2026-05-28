using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatModifier
{
    public virtual void playerTurnStart(Player player) { }
    public virtual void playerDefended(Player player) { }
    public virtual void playerAttacked(Player player) { }
    public virtual void playedCard(Player player, Card card) { }
    public virtual void playerTookDamage(Player player) { }
}
