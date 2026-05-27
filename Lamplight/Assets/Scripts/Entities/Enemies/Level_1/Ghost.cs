using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
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
        addMove(new EnemyAttack(0, 15, "AttackDebuff"));
        addMove(new EnemyAddWeakness(2));
        int startHealth = Random.Range(18, 22);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
}
