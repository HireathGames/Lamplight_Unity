using UnityEngine;
[System.Serializable]
public class AbsintheArtifact : Artifact
{
    public AbsintheArtifact() : base("Absinthe", "At the start of combat gain 1 mania. At the start of your turn add a Delirium with banish to your discard.", 290, new AbsintheArtifactMod(), "Absinthe", true) { }
}
