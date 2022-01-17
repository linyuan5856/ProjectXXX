using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeHitState : State
{
    public IdleState idleState;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats,
       EnemyAnimatorManager enemyAnimatorManager)
    {
        if (enemyManager.isInteracting)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.2f, Time.deltaTime);
            enemyAnimatorManager.anim.SetFloat("Horizontal", 0, 0.2f, Time.deltaTime);
            return this;
        }
        return idleState;
    }


}
