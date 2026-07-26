using UnityEngine;
[System.Serializable]
public class PaletteKnifeArtifact : Artifact
{
    public PaletteKnifeArtifact() : base("Palette Knife", "At the start of combat gain 1 mania.", 400, new PaletteKnifeArtifactMod(), "Palette Knife", true) { }
}
