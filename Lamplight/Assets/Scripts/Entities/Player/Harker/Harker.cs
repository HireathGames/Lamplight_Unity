using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harker : Player
{
    // Start is called before the first frame update
    void Start()
    {
        initialize();
        manager.startCombat();
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
}
