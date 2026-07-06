using UnityEngine;
[System.Serializable]
public class ThespiansMarkArtifact : Artifact
{
    public ThespiansMarkArtifact() : base("Thespians Mark", "At the start of combat, all enemies gain 2 weakness and you gain 2 strength.", 300, new ThespiansMarkArtifactMod(), "Thespians Mark", true) { }
}
