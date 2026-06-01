using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorian : Player
{
    void Start()
    {
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
}
