using UnityEngine;

public class PrisonerEvent : Event
{
    public PrisonerEvent() : base("As you pace the castle halls, you hear pained moans coming from a cell at the end of the hall. Looking inside you see a starved man locked behind bars begging and pleading to be set free. He seems to be so out of it that he doesn’t even notice your presence, the key is just on a table close by. This could be a trap, are you really willing to risk it for a stranger?", new string[3], new string[3], "JH", "Prisoner", false)
    {
        getOptions()[0] = "Help";
        getOptions()[1] = "Ignore";
        getOptions()[2] = "Remember";
        getOutcomes()[0] = "You decide to save them, you unlock the cell and step inside, but no one's there. You turn around but the exit is gone. You have nothing to do but wait: even as the walls start shifting, you wait. Even as days turn to months turn to years turn to centuries turn to eternities. After some time between a moment and all eternity, you are back in the hall, holding something. You gain the Damned Shackle artifact.";
        getOutcomes()[1] = "You leave the scene, you feel guilt but more than that you feel scared. What wanton cruelty made that soul end up in that cell? What would you do if you were in their shoes? No matter how much you try you cannot shake it, an Injustice card was added to your deck.";
        getOutcomes()[2] = "You recognize him, of course you do, it’s you. An empty echo of your past where you were taken prisoner by the Count. Speak to yourself, reassuring yourself that you will kill the count and save everyone. The echo weakly hands you a damaged book, it is your journal from your time and the castle. You gained the Harker’s Journal artifact. ";
    }
    public override void optionOne(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.deck.Add(new Hallucination());
        run.sanity -= 40f;
        if (run.sanity < 0)
        {
            run.sanity = 0;
        }
        manager.saveRun(run);
    }
    public override void optionTwo(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        manager.saveRun(run);
    }
    public override void optionThree(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.deck.Add(new RecurringNightmare());
        manager.saveRun(run);
    }
}
