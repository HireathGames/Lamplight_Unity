using UnityEngine;
[System.Serializable]
public class FinalActArtifact : Artifact
{
    public FinalActArtifact() : base("Final Act", "At the start of combat, add 2 Delirium to your deck and gain 6 regeneration. ", 266, new FinalActArtifacttMod(), "Final Act", true) { }
}
