using UnityEngine;
[System.Serializable]
public class BloodPactArtifact : Artifact
{
    public BloodPactArtifact() : base("Blood Pact", "At the start of combat, gain 4 strength and 3 bleed.", 170, new BloodPactArtifactMod(), "Blood Pact") { }
}
