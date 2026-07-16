using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnifex : Enemy
{
    private int step;
    private int scaling = 2;
    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyDefend(5));
        int startHealth = Random.Range(80, 101);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void playAnimation(int state)
    {
        if (state != -1)
        {
            setAnimatorVariableInt("step", step);
        }
        else
        {
            setAnimatorVariableInt("step", -1);
        }
    }
    public override EnemyMove generateNextMove()
    {
        if (step >= 4)
        {
            return base.generateNextMove();
        }
        if (step == 3)
        {
            return new EnemyExecution(15, scaling);
        }
        else
        {
            return base.generateNextMove();
        }
    }
    public override void takeTurn(Player player)
    {
        if (step >= 3 && !(getNextMove() is EnemyInsanitySkip))
        {
            step = 0;
        }
        else
        {
            step++;
        }
        base.takeTurn(player);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 't')
        {
            bleed += 2;
            critEffects(element);
        }
    }
}
