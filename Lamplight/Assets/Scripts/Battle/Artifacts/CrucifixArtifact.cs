using UnityEngine;
[System.Serializable]
public class CrucifixArtifact : Artifact
{
    public CrucifixArtifact() : base("Crucifix", "At the start of your turn, a random enemy gains 1 mark.", 220, new CrucifixArtifactMod(), "Crucifix", true) { }
}
