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
        addMove(new EnemyAttack(0, 15));
        addMove(new EnemyDefend(3));
    }
}
