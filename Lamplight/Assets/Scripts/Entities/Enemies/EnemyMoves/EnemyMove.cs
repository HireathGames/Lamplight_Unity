using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyMove
{
    public Sprite moveIcon;
    public int animationIndex;
    public EnemyMove(string icon)
    {
        moveIcon = Resources.Load<Sprite>("Sprites/enemy/" + icon);//Put in the name of file as a string
        animationIndex = 1;
    }
    public EnemyMove(string icon, int anim)
    {
        moveIcon = Resources.Load<Sprite>("Sprites/enemy/" + icon);//Put in the name of file as a string
        animationIndex = anim;
    }
    public abstract void performMove(Enemy self, Player player);
    public virtual string getMoveText(Enemy self, Player player)
    {
        return "";
    }
}
