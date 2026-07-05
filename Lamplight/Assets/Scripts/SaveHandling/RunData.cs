using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RunData
{
    //Contains all data for the current run
    public int maxHP;
    public string character; //Initials of the character, example: Jonathan Harker = JH
    public int HP;
    public int sorrows;
    public float sanity;
    public string currentScene;
    public string nextScene;
    public int mapProgress;
    [SerializeReference] public List<Card> deck;//[SerializeReference] needs to be here, it all breaks otherwise. Because it's abstract.
    [SerializeReference] public List<Card> rewardCards;
    [SerializeReference] public List<Card> legendaryRewardCards;
    [SerializeReference] public List<Artifact> heldArtifacts;
    [SerializeReference] public List<Artifact> shopArtifacts;
    [SerializeReference] public List<Event> events;
    [SerializeReference] public List<LevelPiece> nextEncounters;
    public RunData(int health, int max, float sane, List<Card> cards, List<Card> rewards, List<Card> legendaryRewards, string cha, List<Artifact> artifacts = null, List<Event> events = null, int money = 50, List<LevelPiece> encounters = null)
    {
        maxHP = max;
        HP = health;
        sanity = sane;
        deck = cards;
        character = cha;
        rewardCards = rewards;
        legendaryRewardCards = legendaryRewards;
        sorrows = money;
        shopArtifacts = artifacts;
        heldArtifacts = new List<Artifact>();
        nextEncounters = encounters;
        this.events = events;
    }
}
