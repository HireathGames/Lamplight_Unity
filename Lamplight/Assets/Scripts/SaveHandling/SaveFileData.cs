using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SaveFileData
{
    public bool[] characterUnlocks = new bool[4];
    [SerializeReference] public List<Artifact> shopArtifacts;
    [SerializeReference] public List<Event> level_1_Events;
    [SerializeReference] public List<Event> level_2_Events;
    [SerializeReference] public List<Event> level_3_Events;
    [SerializeReference] public List<Card> basicRewards;
    [SerializeReference] public List<Card> basicLegendaryRewards;
    [SerializeReference] public List<Card> harkerRewards;
    [SerializeReference] public List<Card> harkerLegendaryRewards;
    [SerializeReference] public List<Card> frankensteinRewards;
    [SerializeReference] public List<Card> frankensteinLegendaryRewards;
    [SerializeReference] public List<Card> jekyllRewards;
    [SerializeReference] public List<Card> jekyllLegendaryRewards;
    [SerializeReference] public List<Card> dorianRewards;
    [SerializeReference] public List<Card> dorianLegendaryRewards;
    public SaveFileData()
    {
        characterUnlocks[0] = true;
        characterUnlocks[1] = false;
        characterUnlocks[2] = false;
        characterUnlocks[3] = false;
        level_1_Events = new List<Event>();
        level_1_Events.Add(new StormyPathEvent());
        level_1_Events.Add(new MysteryManEvent());
        level_1_Events.Add(new MirrorManEvent());
        shopArtifacts = new List<Artifact>();
        basicRewards = new List<Card>();
        harkerRewards = new List<Card>();
        frankensteinRewards = new List<Card>();
        jekyllRewards = new List<Card>();
        dorianRewards = new List<Card>();
        shopArtifacts.Add(new StarArtifact());
        shopArtifacts.Add(new SunArtifact());
        shopArtifacts.Add(new MoonArtifact());
        shopArtifacts.Add(new BloodPactArtifact());
        basicRewards.Add(new Sadist());
        basicRewards.Add(new Panic());
        basicRewards.Add(new LuckyCoin());
        basicRewards.Add(new Downpour());
        basicRewards.Add(new Comedy());
        basicRewards.Add(new Tragedy());
        basicLegendaryRewards = new List<Card>();
        harkerLegendaryRewards = new List<Card>();
        frankensteinLegendaryRewards = new List<Card>();
        jekyllLegendaryRewards = new List<Card>();
        dorianLegendaryRewards = new List<Card>();
        basicLegendaryRewards.Add(new Hollow());
        basicLegendaryRewards.Add(new Reclamation());
        basicLegendaryRewards.Add(new Determination());
        harkerRewards.Add(new Hunter());
        harkerRewards.Add(new Sacrement());
        harkerRewards.Add(new TillDeath());
        harkerRewards.Add(new BleedingHeart());
        harkerRewards.Add(new Tracker());
        harkerRewards.Add(new ForbiddenHunger());
        harkerLegendaryRewards.Add(new Hemorrhage());
        harkerLegendaryRewards.Add(new Judgment());
        frankensteinRewards.Add(new GraveRobber());
        frankensteinRewards.Add(new Electrify());
        frankensteinRewards.Add(new MadScience());
        frankensteinRewards.Add(new HauntingGlare());
        frankensteinRewards.Add(new Botanist());
        frankensteinRewards.Add(new ExpermentalSerum());
        frankensteinRewards.Add(new Patchwork());
        frankensteinLegendaryRewards.Add(new Necromancy());
        frankensteinLegendaryRewards.Add(new Pyrophobia());
        jekyllRewards.Add(new Shatter());
        jekyllRewards.Add(new Malice());
        jekyllRewards.Add(new Guilt());
        jekyllRewards.Add(new Alive());
        jekyllRewards.Add(new DisapearingAct());
        jekyllRewards.Add(new Psychoanalyse());
        jekyllRewards.Add(new VirtuousPresence());
        jekyllLegendaryRewards.Add(new SinfulShadow());
        jekyllLegendaryRewards.Add(new Murder());
        dorianRewards.Add(new Performance());
        dorianRewards.Add(new ManicMayham());
    }
}
