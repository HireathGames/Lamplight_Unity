using UnityEngine;
[System.Serializable]
public class RedMaskArtifact : Artifact
{
    public RedMaskArtifact() : base("Crimson Mask", "Upon pickup gain 2 Red Death cards. When you play a Red Death card, all enemies gain 3 bleed.", 666, new RedMaskArtifactMod(), "Red Mask", true) { }
}
