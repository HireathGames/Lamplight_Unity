using UnityEngine;

public class MirrorManEvent : Event
{
    public MirrorManEvent() : base("You decide to take refuge in a cabin, all seems well until you see a standing mirror leaning against the wall. You see a figure in it, that isn’t you, it’s shifting and warping. It hurts you to look at but something pulls you in, at this point you can’t force yourself to look away. ", new string[3], new string[3], "HJ&EH", "MirrorMan", false)
    {
        getOptions()[0] = "Look Deeper";
        getOptions()[1] = "Smash it!";
        getOptions()[2] = "Greet Him";
        getOutcomes()[0] = "The shifting figure starts to become more solid and it becomes clear it’s looking at you. It steps out of the mirror and approaches you. It touches your face, gently, lovingly. And you realize that it is you, just you. It is gone, you gained a reflection. ";
        getOutcomes()[1] = "With the last bit of willpower you have, you smash your fist into it. It breaks immediately, shards of glass fly everywhere, some imbedding into your flesh. It seems like whatever it was, it’s gone. You go to remove the glass but you see it’s dissolving into your skin. You gain the artifact Shifting Shards.";
        getOutcomes()[2] = "You tell Hyde that there are simpler ways to get your attention, he tells you to die in a ditch, affectionately. Mirrors have always helped you two have conversations, but you left all them at home. You ask Hyde to break the mirror so you can take it with you, he does so with a smile. You gained a Reflection and the Shifting Shards artifact.";
    }
    public override void optionOne(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.deck.Add(new Reflection());
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
        run.heldArtifacts.Add(new ShiftingShardsArtifact());
        run.HP -= run.HP / 10;
        manager.saveRun(run);
    }
    public override void optionThree(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.deck.Add(new Reflection());
        run.heldArtifacts.Add(new ShiftingShardsArtifact());
        manager.saveRun(run);
    }
}
