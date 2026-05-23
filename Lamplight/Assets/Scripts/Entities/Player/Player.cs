using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Entity
{
    [SerializeField] private int energy;
    [SerializeField] public Enemy focus;//The enemy attacks and debuffs should go onto
    public BattleManager manager;
    private float actionDelay;

    private void Update()
    {
        if (actionDelay >= 0)
        {
            actionDelay -= Time.deltaTime;
        }
    }
    public void setEnergy(int gain) { energy = gain; }
    public int getEnergy() { return energy; }
    public void setDelay(float delay) { actionDelay = delay; }
    public float getDelay() { return actionDelay; }
    public override void die()
    {
        //Add stuff later
    }
    public override void playAnimation(int state)
    {
        base.playAnimation(state);
        actionDelay = 1;
    }

}
