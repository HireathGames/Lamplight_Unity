using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dracula : Enemy
{

    private void Update()
    {

    }
    public override EnemyMove generateNextMove()
    {
        List<EnemyMove> withoutLast = new(GetMoves());
        withoutLast.Remove(getNextMove());
        return withoutLast[Random.Range(0, withoutLast.Count)];
    }
    public override void die()
    {
        playAnimation(-1);
        getManager().fading = true;
        getAnimator().SetInteger("State", -1);
        Invoke("resetAnimation", 2.1f);
        Invoke("exit", 2f);
    }
    private void Awake()
    {
        addMove(new EnemyAttack(10));
        addMove(new EnemyAttack(8, 5, "AttackDebuff", 1));
        addMove(new EnemyGiveAllSArmor(9));
        addMove(new EnemyAddStatusCard(new Gloom(), 1));
        addMove(new EnemyVampireDrink(5, 7, 2));
        int startHealth = 444;
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'b')
        {
            takeDamage(0, 5, 'n');
            critEffects(element);
        }
    }
    public override void playAnimation(int state)
    {
        if (getAnimator() != null)
        {
            getAnimator().SetInteger("State", state);
            Invoke("resetAnimation", 2);
        }
    }
    private void resetAnimation()
    {
        getAnimator().SetInteger("State", 0);
    }
    public void exit()
    {
        PersistentDataManager dataManager = new PersistentDataManager();
        RunData run = getManager().getRun();
        dataManager.saveRun(run);
        SceneManager.LoadScene("Ending_Cutscene");
    }
}
