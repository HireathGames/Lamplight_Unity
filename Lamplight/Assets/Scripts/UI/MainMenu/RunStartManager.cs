using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunStartManager : MonoBehaviour
{
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
        List<Card> rewards = new List<Card>();
        //rewards.Add(new Sadist());
        //rewards.Add(new Panic());
        rewards.Add(new LuckyCoin());
        //rewards.Add(new Downpour());
        rewards.Add(new Comedy());
        manager.saveRun(new RunData(100, 100, 100, deck, rewards));
        SceneManager.LoadScene("Level_1_Map");
    }
}
