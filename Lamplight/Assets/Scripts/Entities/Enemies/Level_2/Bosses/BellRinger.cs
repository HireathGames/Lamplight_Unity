using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BellRinger : Enemy
{
    private BellRingerMod modifier;
    public Transform hand;
    public ParticleSystem start;
    public AudioSource ring;

    private void Awake()
    {
        addMove(new EnemyDefend(10));
        addMove(new EnemyAttack(5, 0, 1));
        addMove(new EnemyGainStrength(5, 3));
        int startHealth = Random.Range(300, 401);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    private void Start()
    {
        modifier = new BellRingerMod(FindAnyObjectByType<Player>(), hand, ring);
        setNextMove(new EnemyAddCombatMod(modifier, "Debuff"));
        updateMoveInfo(null);
    }
    public override void takeTurn(Player player)
    {
        if (getNextMove() is EnemyAddCombatMod)
        {
            ring.Play();
            start.Play();
        }
        base.takeTurn(player);
        if (player.mania <= -3)
        {
            setNextMove(new EnemyAttack(999));
            updateMoveInfo(player);
        }
    }

    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 't')
        {
            broken++;
            critEffects(element);
        }
    }
}
