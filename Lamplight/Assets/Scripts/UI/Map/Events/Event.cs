using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Event
{
    [SerializeField] private string eventDiscriptionInitial;
    [SerializeField] private string[] options;
    [SerializeField] private string[] outcomesDiscription;
    [SerializeField] private string art;
    [SerializeField] private string specialCharacter;
    [SerializeField] private bool levelSpecific;

    public Event(string disc, string[] opt, string[] outcomes, string special, string spr)
    {
        eventDiscriptionInitial = disc;
        options = opt;
        outcomesDiscription = outcomes;
        specialCharacter = special;
        art = spr;
        levelSpecific = true;
    }
    public Event(string disc, string[] opt, string[] outcomes, string special, string spr, bool specific)
    {
        eventDiscriptionInitial = disc;
        options = opt;
        outcomesDiscription = outcomes;
        specialCharacter = special;
        art = spr;
        levelSpecific = specific;
    }
    public abstract void optionOne(RunData run);
    public abstract void optionTwo(RunData run);
    public abstract void optionThree(RunData run);
    public string getDiscription() { return eventDiscriptionInitial; }
    public bool isSpecialCharacter(string character) { return character.Equals(specialCharacter); }
    public string[] getOptions() { return options; }
    public string[] getOutcomes() { return outcomesDiscription; }
    public bool getLevelSpecific() { return levelSpecific; }
    public Sprite getArt()
    {
        return (Resources.Load<Sprite>("Sprites/Events/" + art));
    }
}
