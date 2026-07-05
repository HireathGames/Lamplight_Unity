using UnityEngine;
[System.Serializable]
public class SacredBloodArtifact : Artifact
{
    public SacredBloodArtifact() : base("Sacred Blood", "At the end of combat gain 3 max health.", 0, new SacredBloodArtifactMod(), "Sacred Blood") { }
}
