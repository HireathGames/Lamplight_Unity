using UnityEngine;
[System.Serializable]
public class BunsenBurnerArtifact : Artifact
{
    public BunsenBurnerArtifact() : base("Bunsen Burner", "At the start of your turn, all enemies sanity is reduced by 5.", 200, new BunsenBurnerArtifactMod(), "Bunsen Burner", true) { }
}
