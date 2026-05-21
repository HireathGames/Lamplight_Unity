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
}
