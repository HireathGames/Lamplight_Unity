using UnityEngine;

[System.Serializable]
public class RegretArtifactMod : CombatModifier
{
    [SerializeField] private int amount;
    public RegretArtifactMod(int number)
    {
        amount = number;
    }
    public RegretArtifactMod() { }
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        for (int i = 0; i < amount; i++)
        {
            int ran = Random.Range(0, player.manager.getDeck().Count);
            player.manager.getDeck().Insert(ran, new SinDebuff());
        }
        makeDone();
    }
}
