using UnityEngine;
[System.Serializable]
public class MoonArtifact : Artifact
{
    public MoonArtifact() : base("The Moon", "At the start of combat, all enemies gain 1 weakness.", 185, new MoonArtifactMod(), "The Moon", false) { }
}
