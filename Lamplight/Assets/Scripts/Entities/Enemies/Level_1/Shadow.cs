using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : Enemy
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
        addMove(new EnemyAttack(5));
        addMove(new EnemyDefend(7));
    }
}
