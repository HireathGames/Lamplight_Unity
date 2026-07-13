using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : Enemy
{
    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyAttack(3));
        addMove(new EnemyGainStrength(5, 10, 2));
        addMove(new EnemyDefendAndDrain(10, 10, 3));
        int startHealth = Random.Range(3, 10);
        setHealth(startHealth);
        setMaxHealth(startHealth);
        addArmor(100);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 't' && healthDamage > 0)
        {
            setArmor(getArmor() - 5);
            if (getArmor() < 0)
            {
                setArmor(0);
            }
        }
    }
}
