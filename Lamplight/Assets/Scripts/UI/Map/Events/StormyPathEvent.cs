using UnityEngine;

public class StormyPathEvent : Event
{
    public StormyPathEvent() : base("On the path ahead of you is a mountain pass, a storm is raging above. Braving it would save you time but it might prove treacherous, you could rest here until it passes.", new string[3], new string[3], "VF", "Stormy Path")
    {
        getOptions()[0] = "Brave It";
        getOptions()[1] = "Rest";
        getOptions()[2] = "Harness It";
        getOutcomes()[0] = "The storm is harsh and unyielding, the air is so cold it seems to seep into your very soul. It is not just the cold, it is the very essence of melancholy, it takes root in you. You feel thousands of souls anguish and despair, and end up not being able to distinguish your tears from the rain. As you get on the other side and the storm lets up you feel that it didn’t leave you, but instead bolstered you.";
        getOutcomes()[1] = "You find an overhang safe from rainfall, you set up camp there. The sound of the rain soothes your weary soul, you have restful sleep.";
        getOutcomes()[2] = "You set up your lightning rod and wait, holding it with your reanimated arm. Suddenly with a flash you feel a jolt through your body. But you don’t falter, you absorb all the horrific and profane energy from the bolt of malice, making you stronger.";
    }
    public override void optionOne(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.maxHP += 15;
        run.HP -= run.HP / 4;
        manager.saveRun(run);
    }
    public override void optionTwo(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.HP += run.HP / 2;
        run.sanity = 100f;
        if (run.HP > run.maxHP)
        {
            run.HP = run.maxHP;
        }
        manager.saveRun(run);
    }
    public override void optionThree(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.maxHP += run.maxHP / 5;
        run.HP += run.HP / 4;
        if (run.HP > run.maxHP)
        {
            run.HP = run.maxHP;
        }
        manager.saveRun(run);
    }
}
