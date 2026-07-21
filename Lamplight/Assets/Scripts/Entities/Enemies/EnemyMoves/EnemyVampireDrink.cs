using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVampireDrink : EnemyMove
{
    private int strength;
    private int bleed;
    private int weakness;
    public EnemyVampireDrink(int str, int ble, int weak) : base("Buff", 4)
    {
        strength = str;
        bleed = ble;
        weakness = weak;
    }
    public override void performMove(Enemy self, Player player)
    {
        List<Enemy> targets = new List<Enemy>();
        foreach (Enemy enemy in self.getManager().getEnemies())
        {
            if (enemy is Cattle)
            {
                targets.Add(enemy);
            }           
        }
        if (targets.Count > 0)
        {
            int ran = Random.Range(0, targets.Count);
            targets[ran].bleed += bleed;
            targets[ran].weakness += weakness;
            targets[ran].playAnimation(4);
            self.strength += strength;
        }
        else
        {
            setAnimationIndex(3);
            player.bleed += (bleed / 2);
        }
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return "???";
    }
}
