using UnityEngine;
[System.Serializable]
public class BloodPactArtifact : Artifact
{
    public BloodPactArtifact() : base("Blood Pact", "At the start of combat, gain 3 strength and 3 bleed.", 300, new BloodPactArtifactMod(), "Blood Pact") { }
}
