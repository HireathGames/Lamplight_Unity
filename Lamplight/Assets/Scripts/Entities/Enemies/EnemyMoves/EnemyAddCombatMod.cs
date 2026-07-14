using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddCombatMod : EnemyMove
{
    private CombatModifier modifier;
    public EnemyAddCombatMod(CombatModifier mod, string icon = "Debuff") : base(icon, 3)
    {
        modifier = mod;
    }
    public EnemyAddCombatMod(CombatModifier mod, int anim, string icon = "Debuff") : base(icon, anim)
    {
        modifier = mod;
    }
    public override void performMove(Enemy self, Player player)
    {
        player.addModifier(modifier);
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return "???";
    }
}
