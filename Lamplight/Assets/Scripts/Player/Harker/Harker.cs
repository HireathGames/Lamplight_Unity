using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harker : Player
{
    // Start is called before the first frame update
    void Start()
    {
        //All testing
        manager.getDeck().Add(new BasicAttack("Peirce", 'w'));
        manager.getDeck().Add(new BasicAttack("Peirce", 'w'));
        manager.getDeck().Add(new BasicAttack("Peirce", 'w'));
        manager.getDeck().Add(new BasicDefend("Parry", 'w'));
        manager.getDeck().Add(new BasicDefend("Parry", 'w'));
        manager.getDeck().Add(new BasicDefend("Parry", 'w'));
        manager.startCombat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
