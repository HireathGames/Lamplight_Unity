using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harker : Player
{
    // Start is called before the first frame update
    void Start()
    {
        getDeck().Add(new BasicAttack("Peirce", 'w'));
        getDeck().Add(new BasicAttack("Peirce", 'w'));
        getDeck().Add(new BasicAttack("Peirce", 'w'));
        getDeck().Add(new BasicDefend("Parry", 'w'));
        getDeck().Add(new BasicDefend("Parry", 'w'));
        getDeck().Add(new BasicDefend("Parry", 'w'));
        StartCombat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
