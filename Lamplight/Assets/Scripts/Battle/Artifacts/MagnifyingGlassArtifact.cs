using UnityEngine;
[System.Serializable]
public class MagnifyingGlassArtifact : Artifact
{
    public MagnifyingGlassArtifact() : base("Magnifying Glass", "At the start of your turn, reduce your weakness by 1.", 220, new MagnifyingGlassArtifactMod(), "Magnifying Glass", true) { }
}
