using UnityEngine;

public class CursedTomeEvent : Event
{
    public CursedTomeEvent() : base("While traveling you see a faint flicker in the distance, you go closer and see a floating tome. It is surrounded by petrified people in poses of abject agony. This accursed text floats there, calling. You could destroy it, relieving this world from its malevolence, but you can’t shake the feeling that you are destined to read it.", new string[3], new string[3], "DG", "Cursed Tome")
    {
        getOptions()[0] = "Read";
        getOptions()[1] = "Destroy";
        getOptions()[2] = "Collect";
        getOutcomes()[0] = "As you open the text, you contort in agony. You feel yourself slipping away from this world, falling between the cracks of reality. But then you feel a luminous force, bordering on the divine, cloak you in its light. It seems your patron saved you from the fate of the others, but your mind is still shattered from what you have seen. You gained the grimoire artifact.";
        getOutcomes()[1] = "You set the cursed thing in flames, it makes a sound as if screaming in agony. The petrified figures crumble to dust, freeing them from whatever fate they were subject to. Your soul feels lighter.";
        getOutcomes()[2] = "You never thought you’d see your old dairy again, you pick up a flip it open. It was nice to reminisce about your deeds. How long ago did you bind your former lover's soul to this book? 500, 400 years? Eh, who knows! What matters now is that she is coming with you, you gained the grimoire artifact.";
    }
    public override void optionOne(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.sanity = 0;
        run.heldArtifacts.Add(new GrimoireArtifact());
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
        run.heldArtifacts.Add(new GrimoireArtifact());
        manager.saveRun(run);
    }
}
