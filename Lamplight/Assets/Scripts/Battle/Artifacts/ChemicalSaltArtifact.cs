using UnityEngine;
[System.Serializable]
public class ChemicalSaltArtifact : Artifact
{
    public ChemicalSaltArtifact() : base("Chemical Salt", "At the start of combat, all enemies gain 6 broken.", 190, new MoonArtifactMod(), "Chemical Salt", true) { }
}
