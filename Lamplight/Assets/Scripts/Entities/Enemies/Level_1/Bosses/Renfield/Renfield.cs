using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Renfield : Enemy
{
    private void Awake()
    {
        addMove(new EnemyGainStrength(3, 15, 2));
        addMove(new EnemyAddBleed(5, 2));
        addMove(new EnemyAttack(15));
        addMove(new EnemyAttack(10, 15, "AttackDebuff"));
        int startHealth = Random.Range(200, 230);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    private void Update()
    {
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
    public override void takeTurn(Player player)
    {
        if (getNextMove() is EnemyInsanitySkip)
        {
            strength += 5;
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
