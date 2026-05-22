using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Entity
{
    [SerializeField] private int energy;
    [SerializeField] public Enemy focus;//The enemy attacks and debuffs should go onto
    public BattleManager manager;


    public void setEnergy(int gain) { energy = gain; }
    public int getEnergy() { return energy; }
    public override void die()
    {
        //Add stuff later
    }
}
