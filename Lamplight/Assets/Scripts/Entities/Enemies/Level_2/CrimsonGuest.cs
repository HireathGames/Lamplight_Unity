using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimsonGuest : Enemy
{
    private void Awake()
    {
        addMove(new EnemyDefend(15));
        addMove(new EnemyAttack(15));
        addMove(new EnemyAddStatusCard(new RedDeath(), 3, 3));
        int startHealth = Random.Range(120, 161);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    private void Start()
    {
        setNextMove(new EnemyAddCombatMod(new CrimsonGuestMod(this), "Buff"));
        updateMoveInfo(null);
    }

    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'w')
        {
            mark += 2;
            critEffects(element);
        }
    }
}
