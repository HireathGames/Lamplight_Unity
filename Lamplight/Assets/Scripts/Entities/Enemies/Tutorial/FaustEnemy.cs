using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FaustEnemy : Enemy
{
    private int moveIndex;
    [SerializeField] private Animator tutorial;
    [SerializeField] private TMP_Text dialogueChange;
    private List<Card> newDeck;
    private void Awake()
    {
        addMove(new EnemyDefend(5));
        addMove(new EnemyAttack(10));            
        addMove(new EnemyAttack(0, 100, "AttackDebuff", 1));
        addMove(new EnemyInsanitySkip());
        addMove(new EnemyAttack(999));
        addMove(new EnemyAttack(999));
        addMove(new EnemyAttack(999));
        addMove(new EnemyAttack(999));
        int startHealth = 999;
        setHealth(startHealth);
        setMaxHealth(startHealth);
        newDeck = new List<Card>();
        newDeck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicAttack("Peirce", 'w', "Peirce"));

        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicAttack("Peirce", 'w', "Peirce"));

        newDeck.Add(new Smite());
        newDeck.Add(new Smite());
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new Smite());

        newDeck.Add(new Hunter());
        newDeck.Add(new Sacrement());
        newDeck.Add(new Hunter());
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicAttack("Peirce", 'w', "Peirce"));

        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        newDeck.Add(new BasicDefend("Parry", 'w', "Deflect"));

        Invoke("setUp", 0.05f);
    }
    public override EnemyMove generateNextMove()
    {
        EnemyMove output = GetMoves()[moveIndex];
        return output;
    }
    public override void takeTurn(Player player)
    {
        moveIndex++;
        base.takeTurn(player);
        tutorial.SetInteger("Step", moveIndex);
        setNextMove(GetMoves()[moveIndex]);
        if (getNextMove() is EnemyInsanitySkip && getSanity() > 50)
        {
            dialogueChange.text = "You didn't use my weakness... why? I'm just going to ignore you did that. When an enemy has lowered sanity they have a chance to ''break down'' causing them to skip their turn. That is what I am doing currently.";
            setSanity(0);
        }
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'b')
        {
            setSanity(0);
            critEffects(element);
        }
    }
    private void setUp()
    {
        getManager().replaceDeck(newDeck);
        if (getManager().getHand().Count != 0)
        {
            getManager().discardCard(0);
        }
    }
}
