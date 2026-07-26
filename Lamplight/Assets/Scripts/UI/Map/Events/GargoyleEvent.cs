using UnityEngine;

public class GargoyleEvent : Event
{
    public GargoyleEvent() : base("While wandering the castle, you enter into a garden of sorts. It has beautiful flowers, elegant fountains and wonderful sculptures. Something from the edge of your vision catches your eye, a very valuable looking artifact on the ground. You go to collect it but you notice a large, imposing gargoyle looking directly at it. You feel like whatever it is, it belongs to the statue. ", new string[3], new string[3], "HJ&EH", "Gargoyle", false)
    {
        getOptions()[0] = "Take";
        getOptions()[1] = "Leave";
        getOptions()[2] = "Give";
        getOutcomes()[0] = "You took the object of its focus, and surprisingly it stays static. You feel a sigh of relief wash over you, thinking you got off scott free. But as you go to leave, you are overwhelmed with a deep sadness, like everything you ever loved was taken from you. Two grief cards were added to your deck.";
        getOutcomes()[1] = "You decide to leave it, it is wrong to take what isn’t yours. You don’t know why but the gargoyle seems grateful. You feel better.";
        getOutcomes()[2] = "You pick up and hold it to the gargoyle’s eyes, you ask if it likes shiny trinkets. It doesn’t move but you feel it agreeing. You pull out your metal pocket watch and clip it onto the wing of the peaceful creature. You see some amounts of water flow from its eyes, as if it's crying from joy. A small bit of stone chips from the wing of the gargoyle and falls to the ground, you are worried until it tells you silently it’s for you. You gained the Gargoyle Fragment artifact.";
    }
    public override void optionOne(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        int ran = Random.Range(0, run.shopArtifacts.Count);
        run.heldArtifacts.Add(run.shopArtifacts[ran]);
        if (run.shopArtifacts[ran].isUnique())
        {
            run.shopArtifacts.Remove(run.shopArtifacts[ran]);
        }
        run.deck.Add(new Grief());
        run.deck.Add(new Grief());
        manager.saveRun(run);
    }
    public override void optionTwo(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.sanity += 40f;
        if (run.sanity > 100f)
        {
            run.sanity = 100f;
        }
        manager.saveRun(run);
    }
    public override void optionThree(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.sanity += 40f;
        if (run.sanity > 100f)
        {
            run.sanity = 100f;
        }
        run.heldArtifacts.Add(new GargoyleFragmentArtifact());
        manager.saveRun(run);
    }
}
