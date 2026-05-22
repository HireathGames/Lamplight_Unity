using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int armor;
    //Multipliers for armor gained and damage taken
    [SerializeField] private float armorMod = 1;
    [SerializeField] private float damageMod = 1;
    [SerializeField] private float sanity = 100f;
    //I made status effects public, because it's just easier
    public int mark;
    public int bleed;
    public int strength;
    public int weakness;
    public EntityHealthBar healthBar;
    public int getHealth() { return HP; }
    public void setHealth(int health)
    {
        HP = health;
    }
    public int getArmor() { return armor; }
    public int getMaxHealth() { return maxHP; }
    public float getSanity() { return sanity; }
    public void initialize(int health = 100, int max = 100, float sane = 100f) 
    {
        HP = health;
        maxHP = max;
        sanity = sane;
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
    public void addArmor(int amount)
    {
        armor += (int) (amount * armorMod);
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
    public void takeDamage(int healthDamage, float sanityDamage)
    {
        healthDamage = (int)(healthDamage * (damageMod + (0.5f * mark)));
        if ((healthDamage - armor) > 0)
        {
            HP -= (healthDamage - armor);
            armor = 0;
        }
        else
        {
            armor -= healthDamage;
        }
        if ((sanity - sanityDamage) >= 0)
        {
            sanity -= sanityDamage;
        }
        else
        {
            HP -= (int)((sanityDamage - sanity))/5;
            sanity = 0;
        }
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
        mark = 0;
    }
    public void attackEntity(Entity entity, int healthDamage, float sanityDamage)
    {
        float attackMulti = 1f + (0.2f * strength) - (0.25f * Mathf.Pow(weakness, 0.33f));
        entity.takeDamage((int) (healthDamage * attackMulti), sanityDamage);
    }
}
