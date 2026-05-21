using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harker : Player
{
    // Start is called before the first frame update
    void Start()
    {
        //All testing
        manager.getDeck().Add(new BasicAttack("Peirce", 'w', "Peirce"));
        manager.getDeck().Add(new BasicAttack("Peirce", 'w', "Peirce"));
        manager.getDeck().Add(new BasicAttack("Peirce", 'w', "Peirce"));
        manager.getDeck().Add(new BasicDefend("Parry", 'w', "Deflect"));
        manager.getDeck().Add(new BasicDefend("Parry", 'w', "Deflect"));
        manager.getDeck().Add(new BasicDefend("Parry", 'w', "Deflect"));
        initialize();
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
        manager.startCombat();
    }
}
