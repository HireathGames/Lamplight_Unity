using UnityEngine;
[System.Serializable]
public class GarlicArtifact : Artifact
{
    public GarlicArtifact() : base("Garlic", "At the end of your turn, reduce your bleed by 2.", 160, new GarlicArtifactMod(), "Garlic", true) { }
}
