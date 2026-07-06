using UnityEngine;

public class RedDeathParadeEvent : Event
{
    public RedDeathParadeEvent() : base("You come upon a strange sight, a parade of infected following a robed woman in a mask. They seem to have almost religious reverence for her, even as their bodies decay and fall to pieces. They spot you and immediately start to get ready to attack you, but the cloaked woman stops them. She asks you, “Stranger, do you understand the slander of the blood of those born high commit? Do you understand that blood is not what separates the poor and the noble but what units them? Do you feel the deep wrath of a thousand brothers and sisters left to die by their equals?” She looks at you expectantly.", new string[3], new string[3], "VF", "RedDeathParade", true)
    {
        getOptions()[0] = "Agree";
        getOptions()[1] = "Refute";
        getOptions()[2] = "Speak";
        getOutcomes()[0] = "She looks at you, softly, lovingly and says, “A brother to the flock, you shall cast who you were away. Go forth, make them feel your rage and truth.” She hands you a mask that's… bleeding. You put it on, you gained the Crimson Mask artifact.";
        getOutcomes()[1] = "She looks at you with disgust and disdain, she then nods to her congregation. They then pounce upon you, tearing at your flesh. You end up passing out, you wake up in the arms of Faust under the light of the Midnight Lantern. You were greatly injured but your life was saved by them.";
        getOutcomes()[2] = "You launch into an inane rant the nature of humanity and the ephemeral nature of superiority. You tell about your economic theories and your ideas about the vestiges of feudalistic practices in a modern society. She genuinely looks puzzled by this turn of event and doesn’t know how to react, as she can’t tell if you side with them or not. After exactly 34 minutes an 29 seconds of your speech you finish, they just leave instead of interacting further. That was nice.";
    }
    public override void optionOne(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.deck.Add(new RedDeath());
        run.deck.Add(new RedDeath());
        run.heldArtifacts.Add(new RedMaskArtifact());
        manager.saveRun(run);
    }
    public override void optionTwo(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.HP -= run.HP / 2;
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
        manager.saveRun(run);
    }
}
