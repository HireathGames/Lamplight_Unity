using UnityEngine;
[System.Serializable]
public class GargoyleFragmentArtifact : Artifact
{
    public GargoyleFragmentArtifact() : base("Gargoyle Fragment", "Enemies only lose 50% of their broken when blocking.", 230, new GargoyleFragmentArtifactMod(), "Gargoyle Fragment", true) { }
}
