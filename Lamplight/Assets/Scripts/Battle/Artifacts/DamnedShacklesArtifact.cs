using UnityEngine;
[System.Serializable]
public class DamnedShacklesArtifact: Artifact
{
    public DamnedShacklesArtifact() : base("Damned Shackles", "At the start of your turn, all enemies lose 1 strength.", 290, new DamnedShacklesArtifactMod(), "Damned Shackles", true) { }
}
