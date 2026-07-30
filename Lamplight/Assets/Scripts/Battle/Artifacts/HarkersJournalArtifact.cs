using UnityEngine;
[System.Serializable]
public class HarkersJournalArtifact: Artifact
{
    public HarkersJournalArtifact() : base("Harkers Journal", "At the end of your turn gain armor equal to a third of all enemies bleed.", 300, new HarkersJournalArtifactMod(), "Harkers Journal", false) { }
}
