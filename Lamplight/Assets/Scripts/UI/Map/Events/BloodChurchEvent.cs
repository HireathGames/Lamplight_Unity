using UnityEngine;

public class BloodChurchEvent : Event
{
    public BloodChurchEvent() : base("You come across a lone church, foreboding and ominous. The door is sealed with pulsing red chains. You feel a deep familiar pull towards the gateway, as if your very soul is in the balance. The more you stay here, the more it pulls you in. If you don’t leave immediately you will break down the door.", new string[3], new string[3], "JH", "Blood Church")
    {
        getOptions()[0] = "Stay";
        getOptions()[1] = "Run";
        getOptions()[2] = "Pray";
        getOutcomes()[0] = "You lose control, break down the door with your bare hands. The inside of the church it’s covered floor to ceiling in flesh with a large beating heart above the altar. Your body moves on its own, you approach the heart and strike it with all the force you can muster. You bath in the blood as it gushes out of the heart, it burns but you cannot stop. Eventually you come back to your senses, you gain the Sacred Blood artifact.";
        getOutcomes()[1] = "You run away as fast as you can, not looking back. You feel like you left something behind, something you were meant to find. ";
        getOutcomes()[2] = "You fall to your knees in prayer, asking for protection from your lord. The chains burn up as if they were made of paper. The door unlocks and you enter his holy sanctum, it is bathed in light, you are safe here. You find a golden cross on the altar and decide to take it with you, you gained the Crucifix artifact.";
    }
    public override void optionOne(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.maxHP -= 20;
        if (run.maxHP <= 0)
        {
            run.maxHP = 1;
        }
        if (run.maxHP < run.HP)
        {
            run.HP = run.maxHP;
        }
        run.heldArtifacts.Add(new SacredBloodArtifact());
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
        run.HP += run.HP / 2;
        run.sanity = 100f;
        if (run.HP > run.maxHP)
        {
            run.HP = run.maxHP;
        }
        run.heldArtifacts.Add(new CrucifixArtifact());
        manager.saveRun(run);
    }
}
