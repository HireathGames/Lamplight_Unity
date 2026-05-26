using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RunData
{
    //Contains all data for the current run
    public int maxHP;
    public int HP;
    public float sanity;
    [SerializeReference] public List<Card> deck;//[SerializeReference] needs to be here, it all breaks otherwise. Because it's abstract.
    [SerializeReference] public List<Card> rewardCards;
    [SerializeReference] public List<LevelPiece> nextEncounters;
    public RunData(int health, int max, float sane, List<Card> cards, List<Card> rewards, List<LevelPiece> encounters = null)
    {
        maxHP = max;
        HP = health;
        sanity = sane;
        deck = cards;
        rewardCards = rewards;
        nextEncounters = encounters;
    }
}
