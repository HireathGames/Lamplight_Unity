using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGainStrength : EnemyMove
{
    private int strength;
    private int block = 0;
    public EnemyGainStrength(int str) : base("Buff")
    {
        strength = str;
    }
    public EnemyGainStrength(int str, int anim) : base("Buff", anim)
    {
        strength = str;
    }
    public EnemyGainStrength(int str, int blo, int anim) : base("BlockBuff", anim)
    {
        strength = str;
        block = blo;
    }
    public override void performMove(Enemy self, Player player)
    {
        self.strength += strength;
        self.addArmor(block);
        self.healthBar.updateUI(self);
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return strength.ToString();
    }
}
