using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SaveFileData
{
    public bool[] characterUnlocks = new bool[4];
    [SerializeReference] public List<Card> basicRewards;
    [SerializeReference] public List<Card> basicLegendaryRewards;
    [SerializeReference] public List<Card> harkerRewards;
    [SerializeReference] public List<Card> harkerLegendaryRewards;
    [SerializeReference] public List<Card> frankensteinRewards;
    [SerializeReference] public List<Card> frankensteinLegendaryRewards;
    [SerializeReference] public List<Card> jekyllRewards;
    [SerializeReference] public List<Card> jekyllLegendaryRewards;
    [SerializeReference] public List<Card> dorianRewards;
    [SerializeReference] public List<Card> dorianLegendaryRewards;
    public SaveFileData()
    {
        characterUnlocks[0] = true;
        characterUnlocks[1] = false;
        characterUnlocks[2] = false;
        characterUnlocks[3] = false;
        basicRewards = new List<Card>();
        harkerRewards = new List<Card>();
        frankensteinRewards = new List<Card>();
        jekyllRewards = new List<Card>();
        dorianRewards = new List<Card>();
        basicRewards.Add(new Sadist());
        basicRewards.Add(new Panic());
        basicRewards.Add(new LuckyCoin());
        basicRewards.Add(new Downpour());
        basicRewards.Add(new Comedy());
        basicRewards.Add(new Tragedy());
        basicLegendaryRewards = new List<Card>();
        harkerLegendaryRewards = new List<Card>();
        frankensteinLegendaryRewards = new List<Card>();
        jekyllLegendaryRewards = new List<Card>();
        dorianLegendaryRewards = new List<Card>();
        basicLegendaryRewards.Add(new Hollow());
        basicLegendaryRewards.Add(new Reclamation());
        basicLegendaryRewards.Add(new Determination());
        harkerRewards.Add(new Hunter());
        harkerRewards.Add(new Sacrement());
        harkerRewards.Add(new TillDeath());
        harkerRewards.Add(new BleedingHeart());
        harkerRewards.Add(new Tracker());
        harkerRewards.Add(new ForbiddenHunger());
        harkerLegendaryRewards.Add(new Hemorrhage());
        harkerLegendaryRewards.Add(new Judgment());
        harkerLegendaryRewards.Add(new Judgment());
        harkerLegendaryRewards.Add(new Judgment());
        frankensteinRewards.Add(new GraveRobber());
        frankensteinRewards.Add(new Electrify());
        jekyllRewards.Add(new Shatter());
        jekyllRewards.Add(new Malice());
        dorianRewards.Add(new Performance());
        dorianRewards.Add(new ManicMayham());
    }
}
