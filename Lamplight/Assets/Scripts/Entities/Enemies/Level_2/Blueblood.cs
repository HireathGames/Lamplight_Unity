using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueblood : Enemy
{
    private void Update()
    {
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
    private void Awake()
    {
        addMove(new EnemyDefend(12));
        addMove(new EnemyGiveAllStrength(1, 2));
        addMove(new EnemyAddMark(4, 3));
        int startHealth = Random.Range(35, 50);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override EnemyMove generateNextMove()
    {
        if ((getManager() != null) && (getManager().getEnemies().Count == 1))
        {
            return new EnemyAttack(1);
        }
        else
        {
            return base.generateNextMove();
        }
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'b')
        {
            getManager().getRun().sorrows += 10;
            getManager().updateTextUI();
        }
    }
}
