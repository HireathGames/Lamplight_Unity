using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frankenstein : Player
{
    // Start is called before the first frame update
    void Start()
    {
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
}
