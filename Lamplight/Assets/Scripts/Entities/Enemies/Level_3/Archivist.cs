using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archivist : Enemy
{
    [SerializeField] private SkinnedMeshRenderer mesh;
    [SerializeField] private Material wrath;
    [SerializeField] private Material misery;
    [SerializeField] private Material terror;
    [SerializeField] private Material bliss;
    [SerializeField] private ParticleSystem wrathPartical;
    [SerializeField] private ParticleSystem miseryPartical;
    [SerializeField] private ParticleSystem terrorPartical;
    [SerializeField] private ParticleSystem blissPartical;
    private void Awake()
    {
        addMove(new EnemyAddStatusCard(new Crooked(), 1));
        addMove(new EnemyAddStatusCard(new Crooked(), 1));
        addMove(new EnemyAttack(10));
        addMove(new EnemyDefend(10));
        int startHealth = Random.Range(100, 110);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'w')
        {
            mesh.material = wrath;
            GetMoves()[0] = new EnemyAddStatusCard(new SinDebuff(), 3);
            GetMoves()[1] = new EnemyAddStatusCard(new SinDebuff(), 3);
            wrathPartical.Play();
            miseryPartical.Stop();
            terrorPartical.Stop();
            blissPartical.Stop();
            critEffects(element);
        }
        else if (element == 'm')
        {
            mesh.material = misery;
            GetMoves()[0] = new EnemyAddStatusCard(new Grief(), 1);
            GetMoves()[1] = new EnemyAddStatusCard(new Grief(), 1);
            wrathPartical.Stop();
            miseryPartical.Play();
            terrorPartical.Stop();
            blissPartical.Stop();
            critEffects(element);
        }
        else if (element == 't')
        {
            mesh.material = terror;
            GetMoves()[0] = new EnemyAddStatusCard(new Injustice(), 1);
            GetMoves()[1] = new EnemyAddStatusCard(new Injustice(), 1);
            wrathPartical.Stop();
            miseryPartical.Stop();
            terrorPartical.Play();
            blissPartical.Stop();
            critEffects(element);
        }
        else if (element == 'b')
        {
            mesh.material = bliss;
            GetMoves()[0] = new EnemyAddStatusCard(new Delirium(), 1);
            GetMoves()[1] = new EnemyAddStatusCard(new Delirium(), 1);
            wrathPartical.Stop();
            miseryPartical.Stop();
            terrorPartical.Stop();
            blissPartical.Play();
            critEffects(element);
        }
    }
}
