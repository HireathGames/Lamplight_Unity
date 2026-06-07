using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellain : Enemy
{
    private List<Enemy> summons;
    [SerializeField] private List<Transform> points;
    [SerializeField] private Enemy summonPrefab;
    private void Update()
    {
        if (healthBar != null)
        {
            healthBar.updateUI(this);
        }
        summons.RemoveAll(item => item == null);
        if (summons.Count == 0 && !(getNextMove() is EnemyInsanitySkip))
        {
            setNextMove(new EllainSummonMove());
        }
    }
    private void Awake()
    {
        addMove(new EllainBuffDefendMove());
        addMove(new EllainBuffBreakMove());
        addMove(new EllainBuffDrainMove());
        int startHealth = Random.Range(110, 130);
        summons = new List<Enemy>();
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void die()
    {
        base.die();
        foreach (Enemy e in summons)
        {
            e.die();
        }
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'm')
        {
            foreach (Enemy e in summons)
            {
                e.weakness++;
                e.healthBar.updateUI(e);
            }
        }
    }
    public List<Enemy> getSummons() { return summons; }
    public void summon()
    {
        for (int i = 0; i < points.Count; i++)
        {
            if ((i > summons.Count - 1) || summons[i] == null)
            {
                Enemy enemy = Instantiate(summonPrefab, points[i]);
                enemy.playAnimation(5);
                getManager().getEnemies().Add(enemy);
                summons.Add(enemy);
            }
        }
    }
}
