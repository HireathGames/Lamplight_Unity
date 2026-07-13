using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyAttack(0, 15, "AttackDebuff"));
        addMove(new EnemyAddWeakness(2));
        int startHealth = Random.Range(18, 22);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 't')
        {
            takeDamage(0, 5, 'n');
        }
    }
}
