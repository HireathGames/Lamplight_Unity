using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    private string name;
    private int cost;
    private bool xCost = false;
    private bool banish = false;
    private char type;
    public Card(string n, int c, bool x, bool b, char t)
    {
        name = n;
        cost = c;
        xCost = x;
        banish = b;
        type = t;
    }
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
