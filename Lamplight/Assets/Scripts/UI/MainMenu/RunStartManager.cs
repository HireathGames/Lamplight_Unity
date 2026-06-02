using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class RunStartManager : MonoBehaviour
{
    private PersistentDataManager manager;
    private SaveFileData fileData;

    private void Start()
    {
        manager = new PersistentDataManager();
        if (manager.saveFileExists())
        {
            fileData = manager.loadFile();
        }
    }
    public void newFile()
    {
        fileData = new SaveFileData();
        manager.saveFile(fileData);
    }
    public void startHarkerRun()
    {
        List<Card> deck = new List<Card>();
        deck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        deck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        deck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        deck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        deck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        deck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        deck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        deck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        deck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        deck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        deck.Add(new Hunter());
        deck.Add(new Sacrement());
        RunData run = new RunData(100, 100, 100, deck, combineSetsOfCards(fileData.basicRewards, fileData.harkerRewards), combineSetsOfCards(fileData.basicLegendaryRewards, fileData.harkerLegendaryRewards), "JH");
        manager.saveRun(run);
        SceneManager.LoadScene("Level_1_Map");
    }
    public void startFrankensteinRun()
    {
        List<Card> deck = new List<Card>();
        deck.Add(new BasicAttack("Saw", 't', "Saw"));
        deck.Add(new BasicAttack("Saw", 't', "Saw"));
        deck.Add(new BasicAttack("Saw", 't', "Saw"));
        deck.Add(new BasicDefend("Avoid", 't', "Hide"));
        deck.Add(new BasicAttack("Saw", 't', "Saw"));
        deck.Add(new BasicDefend("Avoid", 't', "Hide"));
        deck.Add(new BasicAttack("Saw", 't', "Saw"));
        deck.Add(new BasicDefend("Avoid", 't', "Hide"));
        deck.Add(new BasicDefend("Avoid", 't', "Hide"));
        deck.Add(new BasicDefend("Avoid", 't', "Hide"));
        deck.Add(new GraveRobber());
        deck.Add(new Electrify());
        RunData run = new RunData(100, 100, 100, deck, combineSetsOfCards(fileData.basicRewards, fileData.frankensteinRewards), combineSetsOfCards(fileData.basicLegendaryRewards, fileData.frankensteinLegendaryRewards), "VF");
        manager.saveRun(run);
        SceneManager.LoadScene("Level_1_Map");
    }
    public void startJekyllRun()
    {
        List<Card> deck = new List<Card>();
        deck.Add(new BasicAttack("Bludgeon", 'w', "Bludgeon"));
        deck.Add(new BasicAttack("Bludgeon", 'w', "Bludgeon"));
        deck.Add(new BasicAttack("Bludgeon", 'w', "Bludgeon"));
        deck.Add(new BasicDefend("Poise", 'm', "Poise"));
        deck.Add(new BasicAttack("Bludgeon", 'w', "Bludgeon"));
        deck.Add(new BasicDefend("Poise", 'm', "Poise"));
        deck.Add(new BasicAttack("Bludgeon", 'w', "Bludgeon"));
        deck.Add(new BasicDefend("Poise", 'm', "Poise"));
        deck.Add(new BasicDefend("Poise", 'm', "Poise"));
        deck.Add(new BasicDefend("Poise", 'm', "Poise"));
        deck.Add(new Malice());
        deck.Add(new Shatter());
        RunData run = new RunData(100, 100, 100, deck, combineSetsOfCards(fileData.basicRewards, fileData.jekyllRewards), combineSetsOfCards(fileData.basicLegendaryRewards, fileData.jekyllLegendaryRewards), "HJ&EH");
        manager.saveRun(run);
        SceneManager.LoadScene("Level_1_Map");
    }
    public void startDorianRun()
    {
        List<Card> deck = new List<Card>();
        deck.Add(new BasicAttack("Slash", 'b', "Slash"));
        deck.Add(new BasicAttack("Slash", 'b', "Slash"));
        deck.Add(new BasicAttack("Slash", 'b', "Slash"));
        deck.Add(new BasicAttack("Slash", 'b', "Slash"));
        deck.Add(new BasicAttack("Slash", 'b', "Slash"));
        deck.Add(new BasicDefend("Dodge", 'b', "Dodge"));
        deck.Add(new BasicDefend("Dodge", 'b', "Dodge"));
        deck.Add(new BasicDefend("Dodge", 'b', "Dodge"));
        deck.Add(new BasicDefend("Dodge", 'b', "Dodge"));
        deck.Add(new BasicDefend("Dodge", 'b', "Dodge"));
        deck.Add(new ManicMayham());
        deck.Add(new Performance());
        RunData run = new RunData(100, 100, 100, deck, combineSetsOfCards(fileData.basicRewards, fileData.dorianRewards), combineSetsOfCards(fileData.basicLegendaryRewards, fileData.dorianLegendaryRewards), "DG");
        manager.saveRun(run);
        SceneManager.LoadScene("Level_1_Map");
    }
    public List<Card> combineSetsOfCards(List<Card> cardsA, List<Card> cardsB)
    {
        List<Card> output = new List<Card>();
        if (cardsA != null)
        {
            foreach (Card c in cardsA)
            {
                output.Add(c);
            }
        }
        if (cardsB != null)
        {
            foreach (Card c in cardsB)
            {
                output.Add(c);
            }
        }
        return (output);
    }
}
