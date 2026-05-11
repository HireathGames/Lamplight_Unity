using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int armor;
    [SerializeField] private float armorMod;
    [SerializeField] private float DamageMod;
    [SerializeField] private float sanity = 100f;
    [SerializeField] private int energy;
    [SerializeField] public Enemy focus;
    [SerializeField] private List<Card> deck = new List<Card>();
    [SerializeField] private List<Card> discard = new List<Card>();
    [SerializeField] private List<Card> hand = new List<Card>();
    public int getHealth() { return HP; }
    public int getArmor() { return armor; }
    public int getMaxHealth() { return maxHP; }
    public float getSanity() { return sanity; }
    public List<Card> getDeck() { return deck; }
    public List<Card> getHand() { return hand; }
    public List<Card> getDiscard() { return discard; }
    public void addArmor(int amount) { armor += amount;}
    public void StartCombat()
    {
        List<Card> setUp = deck;
        shuffle(setUp);
        startTurn();
    }
    public void startTurn()
    {
        for (int i = 0; i < 5; i++)
        {
            draw();
            energy = 3;
        }
    }
    public void draw()
    {
        if (deck.Count == 0)
        {
            shuffle(discard);
        }
        Card drawn = deck[0];
        deck.RemoveAt(0);
        hand.Add(drawn);
    }
    public void discardCard(int handPosition)
    {
        if (hand[handPosition] != null)
        {
            discard.Add(hand[handPosition]);
            hand.RemoveAt(handPosition);
        }
    }
    private void shuffle(List<Card> into)
    {
        int times = into.Count;
        for (int i = 0; i < times; i++)
        {
            int randomCard = Random.Range(0, into.Count);
            deck.Add(into[randomCard]);
            into.RemoveAt(randomCard);
        }
    }
    public void playCard(int handPosition)
    {
        if (hand[handPosition] != null)
        {
            if (hand[handPosition].getIsX())
            {
                hand[handPosition].play(energy, this);
                energy = 0;
            } 
            else
            {
                hand[handPosition].play(hand[handPosition].getCost(), this);
                energy -= hand[handPosition].getCost();
            }
            if (!hand[handPosition].getIsBanished())
            {
                discard.Add(hand[handPosition]);
            }
            hand.RemoveAt(handPosition);
        }
    }
    public void takeDamage(int healthDamage, float sanityDamage)
    {
        if ((healthDamage - armor) > 0)
        {
            HP -= (healthDamage - armor);
            armor = 0;
        }
        else
        {
            armor -= healthDamage;
        }
        if ((sanity - sanityDamage) > 0)
        {
            sanity -= sanityDamage;
        }
        else
        {
            HP -= (int) (sanityDamage - sanity);
            sanity = 0;
        }
    }
}
