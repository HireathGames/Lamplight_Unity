using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
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
    public int regeneration;
    public int broken;
    public int mania;
    public EntityHealthBar healthBar;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public int getHealth() { return HP; }
    public Animator getAnimator() { return animator; }
    public void setHealth(int health)
    {
        HP = health;
    }
    public void setMaxHealth(int max)
    {
        maxHP = max;
    }
    public void setSanity(float sane)
    {
        sanity = sane;
    }
    public void setArmor(int block)
    {
        armor = block;
    }
    public void setDamageMod(float mod)
    {
        if (mod > 0)
        {
            damageMod = mod;
        }
        else
        {
            damageMod = 0;
        }
    }
    public void setArmorMod(float mod)
    {
        if (mod > 0)
        {
            armorMod = mod;
        }
        else
        {
            armorMod = 0;
        }
    }
    public float getArmorMod() { return armorMod; }
    public int getArmor() { return armor; }
    public int getMaxHealth() { return maxHP; }
    public float getSanity() { return sanity; }
    public virtual void initialize(int health = 100, int max = 100, float sane = 100f) 
    {
        HP = health;
        maxHP = max;
        sanity = sane;
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
    public virtual void addArmor(int amount)
    {
        if (broken == 0)
        {
            armor += (int)(amount * armorMod);
        }
        else
        {
            HP -= broken;
            broken = 0;
        }
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
    public virtual void playAnimation(int state)
    {
        if (animator != null)
        {
            animator.SetInteger("State", state);
            Invoke("resetAnimation", 1);
        }
    }
    private void resetAnimation()
    {
        animator.SetInteger("State", 0);
    }
    public virtual void takeDamage(int healthDamage, float sanityDamage, char element)
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
        mark = 0;
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
        if (HP <= 0)
        {
            die();
        }
    }
    public virtual void attackEntity(Entity entity, int healthDamage, float sanityDamage, char element)
    {
        float attackMulti = 1f + (0.2f * strength) - (0.25f * Mathf.Pow(weakness, 0.33f));
        entity.takeDamage((int) (healthDamage * attackMulti), sanityDamage, element);
    }
    public abstract void die();
}
