using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card
{
    //Needs to be intergrated with the UI
    private string name;
    private bool attack;
    private string discription;
    private Sprite cardArt;
    private int cost;
    private bool xCost = false;//Consumes all energy then does an effect a number of time equal to the energy spent
    private bool banish = false;//If true should be removed from play after being played.
    private char type;//Elemental system, valid types are w, m, t, b and n. n is none.
    public Card(string n, string d, int c, bool a, bool x, bool b, char t, string art)
    {
        name = n;
        discription = d;
        cost = c;
        attack = a;
        xCost = x;
        banish = b;
        type = t;
        cardArt = Resources.Load<Sprite>("Sprites/Cards/" + art);//Put in the name of file as a string
    }
    //Energy spent and the player are arguments to make the effects easier to implement
    public abstract void play(int spentEnergy, Player player);
    public string getName() { return name; }
    public string getDiscription() { return discription; }
    public int getCost() { return cost; }
    public Sprite getArt() { return cardArt; }
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
