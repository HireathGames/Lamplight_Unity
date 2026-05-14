using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int armor;
    //Multipliers for armor gained and damage taken
    [SerializeField] private float armorMod;
    [SerializeField] private float DamageMod;
    [SerializeField] private float sanity = 100f;
    [SerializeField] private int energy;
    [SerializeField] public Enemy focus;//The enemy attacks and debuffs should go onto
    public BattleManager manager;

    public int getHealth() { return HP; }
    public int getArmor() { return armor; }
    public int getMaxHealth() { return maxHP; }
    public float getSanity() { return sanity; }
    public void setEnergy(int gain) { energy = gain; }
    public int getEnergy() { return energy; }
    public void addArmor(int amount) { armor += amount;}
    
    public void takeDamage(int healthDamage, float sanityDamage)
    {
        healthDamage = (int) (healthDamage * DamageMod);
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
            HP -= (int) (sanityDamage - sanity);
            sanity = 0;
        }
    }
}
