using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public abstract class Enemy : Entity
{
    [SerializeField] private List<EnemyMove> moves = new List<EnemyMove>();
    [SerializeField] private EnemyMove nextMove;
    [SerializeField] private Image moveIcon;
    [SerializeField] private TMP_Text moveText;
    private BattleManager manager;
    public Player playerChara;
    private int breakDowns;
    private void Start()
    {
        nextMove = generateNextMove();
        manager = FindAnyObjectByType<BattleManager>();
        if (moveIcon != null && moveText != null)
        {
            moveIcon.sprite = nextMove.moveIcon;
            Player player = FindAnyObjectByType<Player>();
            updateMoveInfo(player);
        }
    }
    public virtual EnemyMove generateNextMove()
    {
        return moves[Random.Range(0, moves.Count)];
    }
    public virtual void takeTurn(Player player)
    {
        if (getArmor() > 0)
        {
            setArmor(getArmor() / 2);
        }
        nextMove.performMove(this, player);
        playAnimation(nextMove.animationIndex);
        float skipChance = 0.5f + (getSanity() / 200f);
        if (Random.Range(0f, 1f) < skipChance)  
        {
            nextMove = generateNextMove();
        }
        else
        {
            nextMove = new EnemyInsanitySkip();
            breakDowns++;
        }
        updateMoveInfo(player);
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
    public void updateMoveInfo(Player player)
    {
        if (player != null)
        {
            moveText.text = nextMove.getMoveText(this, player);
        }
    }
    public void addMove(EnemyMove move)
    {
        moves.Add(move);
    }
    public int getBreakdowns()
    {
        return breakDowns;
    }
    public EnemyMove getNextMove()
    {
        return nextMove;
    }
    public void setNextMove(EnemyMove move)
    {
        nextMove = move;
        if (moveIcon != null)
        {
            moveIcon.sprite = nextMove.moveIcon;
        }
    }
    public BattleManager getManager()
    {
        return manager;
    }
    public List<EnemyMove> GetMoves()
    {
        return moves;
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
