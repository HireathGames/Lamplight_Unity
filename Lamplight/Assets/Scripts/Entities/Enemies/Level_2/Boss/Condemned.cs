using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Condemned : Enemy
{
    private Player pla;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private string[] names;
    private int previous;
    private float nameDelay;
    private void Update()
    {
        if (nameDelay > 0)
        {
            nameDelay -= Time.deltaTime;
        }
        else
        {
            changeName();
        }
    }
    private void Awake()
    {
        addMove(new EnemyAttack(8, 0, "Attack"));
        addMove(new EnemyAttack(5, 10, "AttackDebuff"));
        addMove(new EnemyGainStrength(3, 10, 2));
        addMove(new EnemyAddStatusCard(new Injustice(), 1));
        int startHealth = Random.Range(200, 260);
        setHealth(startHealth);
        setMaxHealth(startHealth);
        changeName();
    }
    public override EnemyMove generateNextMove()
    {
        List<EnemyMove> withoutLast = new(GetMoves());
        withoutLast.Remove(getNextMove());
        return withoutLast[Random.Range(0, withoutLast.Count)];
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (pla != null)
        {
            pla.strength++;
            strength++;
        }
        else
        {
            pla = FindAnyObjectByType<Player>();
            if (pla != null)
            {
                pla.strength++;
                strength++;
            }
        }
        if (element == 'w')
        {
            if (pla != null)
            {
                pla.strength++;
                strength++;
            }
            critEffects(element);
        }
    }
    private void changeName()
    {
        int ran = Random.Range(0, names.Length);
        if (ran != previous)
        {
            nameText.text = names[ran] + ", the condemned";
            nameDelay = 0.1f;
            previous = ran;
        }
        else
        {
            changeName();
        }
    }
}
