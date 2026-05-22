using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RunData
{
    //Contains all data for the current run, thi
    public int maxHP;
    public int HP;
    public float sanity;
    [SerializeReference] public List<Card> deck;//[SerializeReference] needs to be here, it all breaks otherwise. Because it's abstract.
    public RunData(int health, int max, float sane, List<Card> cards)
    {
        maxHP = max;
        HP = health;
        sanity = sane;
        deck = cards;
    }
}
