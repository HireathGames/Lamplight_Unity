using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Enemy : Entity
{
    private List<EnemyMove> moves = new List<EnemyMove>();
    [SerializeField] private int nextMove;
    public void takeTurn()
    {
        nextMove = Random.Range(0, moves.Count);
        moves[nextMove].performMove(this);
    }
}
