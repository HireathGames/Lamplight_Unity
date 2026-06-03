using UnityEngine;
[System.Serializable]
public class SunArtifact : Artifact
{
    public SunArtifact() : base("The Sun", "At the start of combat, gain 1 strength.", 225, new SunArtifactMod(), "The Sun", false) { }
}
