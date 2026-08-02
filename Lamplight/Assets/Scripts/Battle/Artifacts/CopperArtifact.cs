using UnityEngine;
[System.Serializable]
public class CopperArtifact : Artifact
{
    public CopperArtifact() : base("Copper", "At the start of combat, gain 20 armor.", 170, new CopperArtifactMod(), "Copper", true) { }
}
