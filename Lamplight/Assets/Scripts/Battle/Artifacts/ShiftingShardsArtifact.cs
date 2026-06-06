using UnityEngine;
[System.Serializable]
public class ShiftingShardsArtifact : Artifact
{
    public ShiftingShardsArtifact() : base("Shifting Shards", "The first time you play a card of each element, gain 4 regeneration.", 999, new ShiftingShardsArtifactMod(), "Shifting Shards") { }
}
