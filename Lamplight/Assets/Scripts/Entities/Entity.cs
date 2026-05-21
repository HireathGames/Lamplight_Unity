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
    public EntityHealthBar healthBar;
    public int getHealth() { return HP; }
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
        armor += amount;
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
    public void takeDamage(int healthDamage, float sanityDamage)
    {
        healthDamage = (int)(healthDamage * damageMod);
        if ((healthDamage - armor) > 0)
        {
            HP -= (healthDamage - armor);
            armor = 0;
        }
        else
        {
            armor -= healthDamage;
        }
        if ((sanity - sanityDamage) > 0)
        {
            sanity -= sanityDamage;
        }
        else
        {
            HP -= (int)(sanityDamage - sanity);
            sanity = 0;
        }
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
}
