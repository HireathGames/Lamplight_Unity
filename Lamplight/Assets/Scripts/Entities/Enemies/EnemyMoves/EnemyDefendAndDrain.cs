using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefendAndDrain : EnemyMove
{
    private int defence;
    private float drain;
    public EnemyDefendAndDrain(int armor, float sanityDamage) : base("BlockDebuff", 2)
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
    public override string getMoveText(Enemy self, Player player)
    {
        if (defence > drain)
        {
            if (self.broken == 0)
            {
                return defence.ToString();
            }
            else
            {
                return 0.ToString();
            }
        }
        else
        {
            return drain.ToString();
        }
    }
}
