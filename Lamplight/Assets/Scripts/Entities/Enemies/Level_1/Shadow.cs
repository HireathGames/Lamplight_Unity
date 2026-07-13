using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : Enemy
{
    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyAttack(5));
        addMove(new EnemyDefend(7));
        int startHealth = Random.Range(12, 16);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'm')
        {
            broken++;
        }
    }
}
