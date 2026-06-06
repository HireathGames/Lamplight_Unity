using UnityEngine;

public class MysteryManEvent : Event
{
    public MysteryManEvent() : base("While walking along the path a cloaked figure approaches you, you sense no malice from it. It holds out a box, offering it to you expectantly.", new string[3], new string[3], "VF", "MysteryMan")
    {
        getOptions()[0] = "Accept";
        getOptions()[1] = "Refuse";
        getOptions()[2] = "Ask";
        getOutcomes()[0] = "You take the box, and open it. There is nothing inside, the nothing starts spreading. Shortly, you are not holding a box, and there is no one in front of you. Your head hurts. You gained the card Hallucination.";
        getOutcomes()[1] = "You refuse, the figure then looks down and walks away, never even speaking a word.";
        getOutcomes()[2] = "You ask him if he has come for you, death nods his head. You feel sheer terror rise in you, you cannot die yet. You must undo your profane work, you must avenge all that you have lost. Before you even realize you take a swing at the figure, and then you blackout. You wake up back at your camp, the same recurring nightmare. You gained a Hallucination. ";
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
        run.deck.Add(new Hallucination());
        manager.saveRun(run);
    }
}
