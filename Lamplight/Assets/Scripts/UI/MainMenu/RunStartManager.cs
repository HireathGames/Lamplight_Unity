using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunStartManager : MonoBehaviour
{
    private List<Card> rewards;
    private void Start()
    {
        rewards = new List<Card>();
        rewards.Add(new Sadist());
        rewards.Add(new Panic());
        rewards.Add(new LuckyCoin());
        rewards.Add(new Downpour());
        rewards.Add(new Comedy());
        rewards.Add(new Tragedy());
    }
    public void startHarkerRun()
    {
        List<Card> deck = new List<Card>();
        PersistentDataManager manager = new PersistentDataManager();
        deck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        deck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        deck.Add(new BasicAttack("Peirce", 'w', "Peirce"));
        deck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        deck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        deck.Add(new BasicDefend("Parry", 'w', "Deflect"));
        deck.Add(new Hunter());
        deck.Add(new Sacrement());
        manager.saveRun(new RunData(100, 100, 100, deck, rewards, "JH"));
        SceneManager.LoadScene("Level_1_Map");
    }
    public void startFrankensteinRun()
    {
        List<Card> deck = new List<Card>();
        PersistentDataManager manager = new PersistentDataManager();
        deck.Add(new BasicAttack("Saw", 't', "Saw"));
        deck.Add(new BasicAttack("Saw", 't', "Saw"));
        deck.Add(new BasicAttack("Saw", 't', "Saw"));
        deck.Add(new BasicDefend("Avoid", 't', "Hide"));
        deck.Add(new BasicDefend("Avoid", 't', "Hide"));
        deck.Add(new BasicDefend("Avoid", 't', "Hide"));
        deck.Add(new GraveRobber());
        deck.Add(new Electrify());
        manager.saveRun(new RunData(100, 100, 100, deck, rewards, "VF"));
        SceneManager.LoadScene("Level_1_Map");
    }
    public void startJekyllRun()
    {
        List<Card> deck = new List<Card>();
        PersistentDataManager manager = new PersistentDataManager();
        deck.Add(new BasicAttack("Bludgeon", 'w', "Bludgeon"));
        deck.Add(new BasicAttack("Bludgeon", 'w', "Bludgeon"));
        deck.Add(new BasicAttack("Bludgeon", 'w', "Bludgeon"));
        deck.Add(new BasicDefend("Poise", 'm', "Poise"));
        deck.Add(new BasicDefend("Poise", 'm', "Poise"));
        deck.Add(new BasicDefend("Poise", 'm', "Poise"));
        deck.Add(new Malice());
        deck.Add(new Shatter());
        manager.saveRun(new RunData(100, 100, 100, deck, rewards, "HJ&EH"));
        SceneManager.LoadScene("Level_1_Map");
    }
}
