using UnityEngine;
[System.Serializable]
public class RegretArtifact : Artifact
{
    public RegretArtifact(string artifactName, int amount) : base(artifactName, "At the start of combat add " + amount + " sin cards into your deck.", 0, new RegretArtifactMod(amount), "Regret", false) 
    {
    
    }
}
