using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    //Needs to be intergrated with the UI
    private string name;
    private int cost;
    private bool xCost = false;//Consumes all energy then does an effect a number of time equal to the energy spent
    private bool banish = false;//If true should be removed from play after being played.
    private char type;//Elemental system, valid types are w, m, t, b and n. n is none.
    public Card(string n, int c, bool x, bool b, char t)
    {
        name = n;
        cost = c;
        xCost = x;
        banish = b;
        type = t;
    }
    //Energy spent and the player are arguments to make the effects easier to implement
    public abstract void play(int spentEnergy, Player player);
    public string getName() { return name; }
    public int getCost() { return cost; }
    public void setCost(int c) { cost = c; }
    public bool getIsX() { return xCost; }
    public bool getIsBanished() { return banish; }
    public char getType() { return type; }
    public override string ToString()
    {
        return name;
    }
}
