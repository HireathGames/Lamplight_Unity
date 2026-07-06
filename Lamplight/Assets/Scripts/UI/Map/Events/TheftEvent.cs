using UnityEngine;

public class TheftEvent : Event
{
    public TheftEvent() : base("As you walk along the path you see another's campsite. They are singing a tone and not paying attention. You see a bag of some sort of trinket, it looks very valuable. You could strike up a chat with this person, it would be nice, or you could steal from them.", new string[3], new string[3], "JH", "Theft", false)
    {
        getOptions()[0] = "Chat";
        getOptions()[1] = "Steal";
        getOptions()[2] = "Drink";
        getOutcomes()[0] = "You greet the figure, they are surprised by you but not unpleasantly so. They tell their name is Lenore and they are on a quest to find their missing husband. You both revel in the wonder of speaking to a normal person. She lets you rest at her campsite, after having an extremely restful sleep you awake refreshed and ready to brave the gloom once more.";
        getOutcomes()[1] = "You quietly swipe the bag, without the person noticing anything. Going through the bag you find several things, among them is a powerful artifact and a locket. The locket has a picture of a family with a small child in it. You feel awful about swiping this precious item, but it is too late to return. You gained the Thief regret as well as a random artifact.";
        getOutcomes()[2] = "Though the transformation is not yet complete, you feel the hunger of the vampire. The angel is the only reason you are not one as of yet. And here in front of you is a succulent morsel ready for your growing fangs. You cannot resist, you drink her dry. Once the act is done you are struck with an otherworldly guilt, you are a murderer.";
    }
    public override void optionOne(RunData run)
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
    public override void optionTwo(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        int ran = Random.Range(0, run.shopArtifacts.Count);
        run.heldArtifacts.Add(run.shopArtifacts[ran]);
        if (run.shopArtifacts[ran].isUnique())
        {
            run.shopArtifacts.Remove(run.shopArtifacts[ran]);
        }
        run.heldArtifacts.Add(new RegretArtifact("Theif", 1));
        manager.saveRun(run);
    }
    public override void optionThree(RunData run)
    {
        PersistentDataManager manager = new PersistentDataManager();
        run.maxHP += 50;
        run.HP += run.HP / 6;
        if (run.HP > run.maxHP)
        {
            run.HP = run.maxHP;
        }
        run.heldArtifacts.Add(new RegretArtifact("Murderer", 3));
        manager.saveRun(run);
    }
}
