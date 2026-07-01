using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefendAndDrain : EnemyMove
{
    private int defence;
    private float drain;
    public EnemyDefendAndDrain(int armor, float sanityDamage) : base("DebuffBlock", 2)
    {
        defence = armor;
        drain = sanityDamage;
    }
    public EnemyDefendAndDrain(int armor, float sanityDamage, int anim) : base("BlockDebuff", anim)
    {
        defence = armor;
        drain = sanityDamage;
    }
    public override void performMove(Enemy self, Player player)
    {
        self.addArmor(defence);
        self.attackEntity(player, 0, drain, 't');
    }
}
