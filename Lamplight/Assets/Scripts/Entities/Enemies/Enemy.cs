using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class Enemy : Entity
{
    [SerializeField] private List<EnemyMove> moves = new List<EnemyMove>();
    [SerializeField] private EnemyMove nextMove;
    [SerializeField] private Image moveIcon;
    private BattleManager manager;
    private void Start()
    {
        nextMove = moves[Random.Range(0, moves.Count)];
        manager = FindAnyObjectByType<BattleManager>();
        if (moveIcon != null)
        {
            moveIcon.sprite = nextMove.moveIcon;
        }
    }
    public void takeTurn(Player player)
    {
        if (getArmor() > 0)
        {
            setArmor(getArmor() / 2);
            healthBar.updateUI(this);
        }
        nextMove.performMove(this, player);
        playAnimation(nextMove.animationIndex);
        float skipChance = 0.5f + (getSanity() / 200f);
        if (Random.Range(0f, 1f) < skipChance)  
        {
            nextMove = moves[Random.Range(0, moves.Count)];
        }
        else
        {
            nextMove = new EnemyInsanitySkip();
        }
        if (moveIcon != null)
        {
            moveIcon.sprite = nextMove.moveIcon;
        }
        if (bleed > 0)
        {
            setHealth(getHealth() - bleed);
            bleed--;
        }
        if (getHealth() <= 0)
        {
            die();
        }
    }
    public void addMove(EnemyMove move)
    {
        moves.Add(move);
    }
    public override void die()
    {
        playAnimation(-1);
        Invoke("invoDestroy", 1);
    }
    private void invoDestroy()
    {
        Destroy(gameObject);
    }
}
