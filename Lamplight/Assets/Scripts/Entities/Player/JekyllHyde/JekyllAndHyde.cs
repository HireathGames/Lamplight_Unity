using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ParticleSystemJobs;

public class JekyllAndHyde : Player
{
    private float vice;
    public Slider viceBar;
    private bool transformed;
    private bool played;
    public ParticleSystem system;
    private void FixedUpdate()
    {
        if ((transformed != played) && (getDelay() <= 0))
        {
            played = transformed;
            getAnimator().SetBool("Transformed", transformed);
            Invoke("playEffect", 1.15f);
            setDelay(1.5f);
        }
    }
    public void playEffect()
    {
        system.Play();
    }
    void Start()
    {
        setArmorMod(1.5f);
        setDamageMod(1);
        viceBar.value = 0;
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
    }
    public float getVice() { return vice; }
    public void changeVice(float change)
    {
        vice += change;
        if (vice >= 1)
        {
            if (!transformed)
            {
                setArmorMod(1f);
                setDamageMod(2f);
                strength += 5;
                healthBar.updateUI(this);
                transformed = true;
                vice = 1;
            }
            else
            {
                vice = 1;
            }
        }
        else if (vice <= 0)
        {
            if (transformed)
            {
                setArmorMod(1.5f);
                setDamageMod(1f);
                strength -= 5;
                healthBar.updateUI(this);
                transformed = false;
                vice = 0;
            }
            else
            {
                vice = 0;
            }
        }
        viceBar.value = vice;
    }
    public override void playCardModUpdate(Card c)
    {
        base.playCardModUpdate(c);
        if (c.getType() == 'w')
        {
            changeVice(0.4f);
        }
        else if ((c.getType() == 'b') || (c.getType() == 't'))
        {
            changeVice(0.2f);
        }
        else if (c.getType() == 'm')
        {
            changeVice(-0.6f);
        }
    }
}
