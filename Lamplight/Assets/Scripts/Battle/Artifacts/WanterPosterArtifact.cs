using UnityEngine;
[System.Serializable]
public class WanterPosterArtifact: Artifact
{
    public WanterPosterArtifact() : base("Wanter Poster", "At the start of combat, gain 3 strength and 3 mark.", 200, new WanterPosterArtifactMod(), "Wanter Poster", true) { }
}
