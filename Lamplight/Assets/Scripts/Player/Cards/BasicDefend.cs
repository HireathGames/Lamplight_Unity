using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDefend : Card
{
    public BasicDefend(string n, char t) : base(n, 1, false, false, t) { }
    public override void play(int spentEnergy, Player player)
    {
        player.addArmor(5);
    }
}
