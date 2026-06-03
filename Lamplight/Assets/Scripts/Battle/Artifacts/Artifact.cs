using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class Artifact
{
    private string spriteFile;
    private string name;
    private string discription;
    private int cost;
    private bool unique;
    private CombatModifier effect;
    public Artifact(string name, string disc, int cost, CombatModifier effect, string art, bool unique = true)
    {
        this.name = name;
        this.discription = disc;
        this.cost = cost;
        this.effect = effect;
        this.spriteFile = art;
        this.unique = unique;
    }
    public Sprite getArt()
    {
        return (Resources.Load<Sprite>("Sprites/Artifacts/" + spriteFile));
    }
    public bool isUnique() { return unique; }
    public string getName() { return name; }
    public string getDiscription() { return discription; }
    public int getCost() { return cost; }
    public void randomizeCost() { cost += Random.Range(-cost / 10, cost / 10); }
    public CombatModifier getEffect() { return effect; }

}
