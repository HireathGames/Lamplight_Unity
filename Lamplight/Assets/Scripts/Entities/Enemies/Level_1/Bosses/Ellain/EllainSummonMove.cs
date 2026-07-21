using UnityEngine;

public class EllainSummonMove : EnemyMove
{
    public EllainSummonMove() : base("Buff", 1) { }
    public override void performMove(Enemy self, Player player)
    {
        if (self.GetComponent<Ellain>() != null)
        {
            self.GetComponent<Ellain>().summon(player);
        }
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return "???";
    }
}
