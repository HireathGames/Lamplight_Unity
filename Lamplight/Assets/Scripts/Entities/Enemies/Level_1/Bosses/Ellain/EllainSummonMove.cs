using UnityEngine;

public class EllainSummonMove : EnemyMove
{
    public EllainSummonMove() : base("Buff", 1) { }
    public override void performMove(Enemy self, Player player)
    {
        self.GetComponent<Ellain>().summon();
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return "???";
    }
}
