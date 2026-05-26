using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Enemy : Entity
{
    [SerializeField] private List<EnemyMove> moves = new List<EnemyMove>();
    [SerializeField] private int nextMove;
    private BattleManager manager;
    private void Start()
    {
        nextMove = Random.Range(0, moves.Count);
        manager = FindObjectOfType<BattleManager>();
    }
    public void takeTurn(Player player)
    {
        moves[nextMove].performMove(this, player);
        nextMove = Random.Range(0, moves.Count);
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
        Destroy(gameObject);
    }
}
