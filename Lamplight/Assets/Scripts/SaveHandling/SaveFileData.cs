using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SaveFileData
{
    public bool[] characterUnlocks = new bool[4];
    [SerializeReference] public List<Card> basicRewards;
    [SerializeReference] public List<Card> basicLegendaryRewards;
    public SaveFileData()
    {
        characterUnlocks[0] = true;
        characterUnlocks[1] = false;
        characterUnlocks[2] = false;
        characterUnlocks[3] = false;
        basicRewards = new List<Card>();
        basicRewards.Add(new Sadist());
        basicRewards.Add(new Panic());
        basicRewards.Add(new LuckyCoin());
        basicRewards.Add(new Downpour());
        basicRewards.Add(new Comedy());
        basicRewards.Add(new Tragedy());
        basicLegendaryRewards = new List<Card>();
        basicLegendaryRewards.Add(new Hollow());
        basicLegendaryRewards.Add(new Reclamation());
        basicLegendaryRewards.Add(new Determination());
    }
}
