using UnityEngine;
[System.Serializable]
public class GrimoireArtifact : Artifact
{
    public GrimoireArtifact() : base("Grimoire", "At the start of combat, regain 10 sanity.", 666, new GrimoireArtifactMod(), "Grimoire", false) { }
}
