using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddMark : EnemyMove
{
    private int marked;
    public EnemyAddMark(int mark) : base("Debuff")
    {
        marked = mark;
    }
    public EnemyAddMark(int mark, int anim) : base("Debuff", anim)
    {
        marked = mark;
    }
    public override void performMove(Enemy self, Player player)
    {
        player.mark += marked;
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return marked.ToString();
    }
}
