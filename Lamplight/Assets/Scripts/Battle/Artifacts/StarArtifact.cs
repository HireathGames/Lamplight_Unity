using UnityEngine;
[System.Serializable]
public class StarArtifact : Artifact
{
    public StarArtifact() : base("The Star", "At the start of combat, gain 3 regeneration.", 250, new StarArtifactMod(), "The Star", false) { }
}
