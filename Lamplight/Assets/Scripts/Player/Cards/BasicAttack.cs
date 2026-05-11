using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Card
{
    public BasicAttack(string n, char t) : base(n, 1, false, false, t){}
    public override void play(int spentEnergy, Player player)
    {
        player.focus.takeDamage(5, 0);
    }
}
