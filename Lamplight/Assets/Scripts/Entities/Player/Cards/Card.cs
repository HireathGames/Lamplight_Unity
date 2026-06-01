using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//Makes the class able to be serialized
public abstract class Card
{
    //[SerializeField] makes it saved even if it is private, it also makes it changable in editor so I use it like that sometimes.
    [SerializeField] private string name;
    [SerializeField] private bool attack;
    [SerializeField] private int originalCost;
    [SerializeField] private string discription;
    [SerializeField] private string artName;//Keeps track of the original file name of the sprite
    [SerializeField] private Sprite cardArt;
    [SerializeField] private string altArtName;//Keeps track of the original file name of the sprite
    [SerializeField] private Sprite altCardArt;
    [SerializeField] private int cost;
    [SerializeField] private bool xCost = false;//Consumes all energy then does an effect a number of time equal to the energy spent
    [SerializeField] private bool banish = false;//If true should be removed from play after being played.
    [SerializeField] private char type;//Elemental system, valid types are w, m, t, b and n. n is none.
    public Card(string n, string d, int c, bool a, bool x, bool b, char t, string art)
    {
        name = n;
        discription = d;
        originalCost = c;
        cost = originalCost;
        attack = a;
        xCost = x;
        banish = b;
        type = t;
        artName = art;
        altArtName = art;
    }
    public Card(string n, string d, int c, bool a, bool x, bool b, char t, string art, string alt)
    {
        name = n;
        discription = d;
        originalCost = c;
        cost = originalCost;
        attack = a;
        xCost = x;
        banish = b;
        type = t;
        artName = art;
        altArtName = alt;
    }
    public void loadArt()
    {
        cardArt = Resources.Load<Sprite>("Sprites/Cards/" + artName);//Put in the name of file as a string
        altCardArt = Resources.Load<Sprite>("Sprites/Cards/" + altArtName);//Put in the name of file as a string
    }
    //Energy spent and the player are arguments to make the effects easier to implement
    public abstract void play(int spentEnergy, Player player);
    public string getName() { return name; }
    public void resetCost()
    {
        cost = originalCost;
    }
    public string getArtName () { return artName; }
    public string getDiscription() { return discription; }
    public int getCost() { return cost; }
    public Sprite getArt() { return cardArt; }
    public Sprite getAlt() { return altCardArt; }
    public void setCost(int c) { cost = c; }
    public bool getIsX() { return xCost; }
    public bool getIsAttack() { return attack; }
    public bool getIsBanished() { return banish; }
    public char getType() { return type; }
    public override string ToString()
    {
        return name;
    }
}
