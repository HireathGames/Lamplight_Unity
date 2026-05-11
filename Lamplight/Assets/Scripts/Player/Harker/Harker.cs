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
        foreach (Card c in getHand())
        {
            Debug.Log(c);
        }
        playCard(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
