using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInsanitySkip : EnemyMove
{
    public EnemyInsanitySkip() : base("Insanity", -2)
    {

    }
    public override void performMove(Enemy self, Player player)
    {
        
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return "???";
    }
}
