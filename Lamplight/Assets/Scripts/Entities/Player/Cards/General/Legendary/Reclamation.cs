using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reclamation : Card
{
    public Reclamation() : base("Reclamation", "Add one random card into your hand, it costs 0.", 0, false, false, true, 'm', "Reclamation", "ReclamationAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        PersistentDataManager manager = new PersistentDataManager();
        List<Card> cards = new List<Card>();
        RunData run = manager.loadRun();
        foreach(Card c in run.rewardCards)
        {
            c.setCost(0);
            cards.Add(c);
        }
        foreach (Card c in run.legendaryRewardCards)
        {
            c.setCost(0);
            cards.Add(c);
        }
        Card added = cards[Random.Range(0, cards.Count)];
        player.manager.getDeck().Insert(0, added);
        player.manager.draw();
        player.playAnimation(3);
    }
}
