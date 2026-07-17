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
    [SerializeField] private AudioSource critSound;
    [SerializeField] private ParticleSystem critEffect;
    private BattleManager manager;
    private int breakDowns;
    private void Start()
    {
        manager = FindAnyObjectByType<BattleManager>();
    }
    public virtual EnemyMove generateNextMove()
    {
        if (moves != null && moves.Count > 0)
        {
            return moves[Random.Range(0, moves.Count)];
        }
        else
        {
            return new EnemyAttack(1);
        }
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
        if (nextMove != null)
        {
            if ((player != null) && (moveIcon != null && moveText != null))
            {
                moveIcon.sprite = nextMove.moveIcon;
                moveText.text = nextMove.getMoveText(this, player);
            }
            else if (moveIcon != null && moveText != null)
            {
                moveIcon.sprite = nextMove.moveIcon;
                moveText.text = "???";
            }
        }
        else
        {
            nextMove = generateNextMove();
            updateMoveInfo(player);
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
    public void critEffects(char element)
    {
        if ((critEffect != null) && (critSound != null))
        {
            critSound.pitch = Random.Range(2.9f, 3.1f);
            critSound.Play();
            if (element == 't')
            {
                critEffect.startColor = new Color(255, 255, 255);
            }
            else if (element == 'w')
            {
                critEffect.startColor = new Color(255, 0, 0);
            }
            else if (element == 'm')
            {
                critEffect.startColor = new Color(0, 0, 255);
            }
            else if (element == 'b')
            {
                critEffect.startColor = new Color(255, 255, 0);
            }
            critEffect.Play();
        }
    }
}
