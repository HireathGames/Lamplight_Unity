using UnityEngine;

public class PitAndPendulumEvent : Event
{
    public PitAndPendulumEvent() : base("You hear a cry from a nearby house, you rush in, finding a man tied to a table with a swing pendulum above him. Every swing it gets closer and closer, its razor sharp edge ever inching closer to the end of the man's life. The man shouts, that he is very wealthy and can pay you for saving him. Nearby an uncharacteristically peaceful bobby stands, he says that the price for the man’s freedom is blood. What do you do? ", new string[3], new string[3], "HJ&EH", "PitAndPendulum", true)
    {
        getOptions()[0] = "Free Him";
        getOptions()[1] = "Leave Him";
        getOptions()[2] = "Murder!";
        getOutcomes()[0] = "You decide to pay the blood price, giving a few liters to the bobby. The shackles unlatch and he runs over you thanking you and giving you a pouch of a strange currency. You gained 200 sorrows.";
        getOutcomes()[1] = "You refuse, leaving the man to his morbid fate. You try not to look back when the screams grow louder and louder. You try not to cry when they stop completely, you keep telling yourself it’s not your fault. But you know you're lying, don’t you? You gained the Complicit regret. ";
        getOutcomes()[2] = "This horrific scene invokes a primal wrath in Hyde, he takes the cane and bludgeons the pig to death. He almost forgets to save the man because of the joy stomping in the pigs head. He gets him free, but at this point he is more terrified of Hyde than his macabre fate. He shoves a strange currency into your hands and fleas. Jekyll knows that this may be more trouble than its worth. You gained 200 sorrows and the Wanted Poster artifact.";
    }
    public override void optionOne(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.maxHP -= 15;
        if (run.maxHP <= 0)
        {
            run.maxHP = 1;
        }
        if (run.maxHP < run.HP)
        {
            run.HP = run.maxHP;
        }
        run.sorrows += 200;
        manager.saveRun(run);
    }
    public override void optionTwo(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.heldArtifacts.Add(new RegretArtifact("Complicit", 2));
        manager.saveRun(run);
    }
    public override void optionThree(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.sorrows += 200;
        run.heldArtifacts.Add(new WanterPosterArtifact());
        manager.saveRun(run);
    }
}
