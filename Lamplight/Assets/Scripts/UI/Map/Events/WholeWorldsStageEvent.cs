using UnityEngine;

public class WholeWorldsStageEvent : Event
{
    public WholeWorldsStageEvent() : base("As you pass through a door you arrive in a theater, you turn to leave but the exit has vanished. Two masked figures stand upon the stage, one of comedy and one of tragedy. The comedic one speaks, “Come forth! Show yourself to be a true man of the arts!” The tragic one merely stands there shaking their head. Do you give them a show? ", new string[3], new string[3], "DG", "Theater", false)
    {
        getOptions()[0] = "Perform";
        getOptions()[1] = "Refuse";
        getOptions()[2] = "Leave";
        getOutcomes()[0] = "You get up on the stage and perform your heart out, but this is not received well. An audience materializes just to boo and heckle you. By the time it’s over you are almost to tears, but the masked figures seem happy. They come up to you and give you your own mask. You gained the Thespians Mark artifact.";
        getOutcomes()[1] = "You stanchly refuse, the comedy mask cracks at this. You then feel yourself burning from the inside, you burst out laughing. Harder than you ever thought possible, it hurts, so so much. Then you hear something shatter, the comedic one is gone, leaving only tragedy. He looks at you with pity, you have lost something you can never get back. He gives you a mask and sends you on your way. You gained the Thespians Mark artifact.";
        getOutcomes()[2] = "You think to yourself, damn this to hell, whatever metaphysical balderdash this is it doesn’t concern you. You turn right on around and open a portal back to reality before any entity could stop you. Nothing happened.";
    }
    public override void optionOne(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.sanity = 0;
        run.heldArtifacts.Add(new ThespiansMarkArtifact());
        manager.saveRun(run);
    }
    public override void optionTwo(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.maxHP -= 10;
        if (run.maxHP <= 0)
        {
            run.maxHP = 1;
        }
        if (run.maxHP < run.HP)
        {
            run.HP = run.maxHP;
        }
        run.heldArtifacts.Add(new ThespiansMarkArtifact());
        manager.saveRun(run);
    }
    public override void optionThree(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        manager.saveRun(run);
    }
}
