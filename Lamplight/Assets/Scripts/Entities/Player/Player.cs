using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Entity
{
    [SerializeField] private int energy;
    [SerializeField] public Enemy focus;//The enemy attacks and debuffs should go onto
    private List<CombatModifier> modifiers = new List<CombatModifier>();
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
    public void addModifier(CombatModifier mod)
    {
        modifiers.Add(mod);
    }
    public override void addArmor(int amount)
    {
        base.addArmor(amount);
        foreach (CombatModifier mod in modifiers)
        {
            mod.playerDefended(this);
        }
    }
    public void initialize(int health = 100, int max = 100, float sane = 100, BattleManager battle = null)
    {
        base.initialize(health, max, sane);
        manager = battle;
    }
    public override void attackEntity(Entity entity, int healthDamage, float sanityDamage)
    {
        base.attackEntity(entity, healthDamage, sanityDamage);
        foreach (CombatModifier mod in modifiers)
        {
            mod.playerAttacked(this);
        }
    }
    public override void takeDamage(int healthDamage, float sanityDamage)
    {
        base.takeDamage(healthDamage, sanityDamage);
        foreach (CombatModifier mod in modifiers)
        {
            mod.playerTookDamage(this);
        }
    }
    public void turnModUpdate()
    {
        foreach (CombatModifier mod in modifiers)
        {
            mod.playerTurnStart(this);
        }
        if (regeneration > 0)
        {
            setHealth(getHealth() + regeneration);
            regeneration--;
            if (getHealth() > getMaxHealth())
            {
                setHealth(getMaxHealth());
            }
            healthBar.updateUI(this);
        }
        if (bleed > 0)
        {
            setHealth(getHealth() - bleed);
            bleed--;
            healthBar.updateUI(this);
        }
    }
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
