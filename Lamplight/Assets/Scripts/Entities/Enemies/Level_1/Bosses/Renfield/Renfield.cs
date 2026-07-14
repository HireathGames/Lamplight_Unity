using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Renfield : Enemy
{
    private void Awake()
    {
        addMove(new EnemyGainStrength(3, 15, 2));
        addMove(new EnemyAddBleed(3, 2));
        addMove(new EnemyAttack(15));
        addMove(new EnemyAttack(10, 15, "AttackDebuff"));
        int startHealth = Random.Range(200, 230);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override EnemyMove generateNextMove()
    {
        List<EnemyMove> withoutLast = new(GetMoves());
        withoutLast.Remove(getNextMove());
        return withoutLast[Random.Range(0, withoutLast.Count)];
    }
    public override void takeTurn(Player player)
    {
        if (getNextMove() is EnemyInsanitySkip)
        {
            strength += 3;
        }
        base.takeTurn(player);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'b')
        {
            bleed++;
        }
    }
}
