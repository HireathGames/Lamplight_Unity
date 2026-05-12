using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int HP = 10;
    [SerializeField] private int maxHP = 10;
    [SerializeField] private int armor;
    [SerializeField] private float sanity = 100.0f;
    private List<EnemyMove> moves = new List<EnemyMove>();
    [SerializeField] private int nextMove;
    public int getHealth() { return HP; }
    public int getMaxHealth() { return maxHP; }
    public float getSanity() { return sanity; }
    public void takeDamage(int healthDamage, float sanityDamage)
    {
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
    }
    public void takeTurn()
    {
        nextMove = Random.Range(0, moves.Count);
        moves[nextMove].performMove(this);
    }
}
