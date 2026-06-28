using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hemorrhage : Card
{
    private int amount = 2;
    public Hemorrhage() : base("Hemorrhage", "Gain 10 armor and apply 2 bleed to all enemies. After playing double the bleed added by this card.", 2, false, false, false, 'w', "Hemorrhage", "HemorrhageAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addArmor(10);
        foreach (Enemy e in player.manager.getEnemies())
        {
            e.bleed += amount;
            e.healthBar.updateUI(e);
        }
        amount *= 2;
        player.playAnimation(3);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Gain " + modifiedArmor(entity, 5) + " armor and apply " + amount + " bleed to all enemies. After playing double the bleed added by this card.");
    }
}
