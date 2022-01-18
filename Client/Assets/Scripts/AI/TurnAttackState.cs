using System.Collections;
using UnityEngine;

public class TurnAttackState : State
{
    public float maximumTurnAngle = 180;
    public float minimumTurnAngle = -180;
    public CombatStanceState combatStanceState;
   // public float JumpSpeed = 2;
    public float currentRecoverTimer = 3;
    public bool hasPerformedTurnAttack = false;


    public override void OnEnter(EnemyManager enemyManager, EnemyStats enemyStats,
        EnemyAnimatorManager enemyAnimatorManager)
    {
        base.OnEnter(enemyManager, enemyStats, enemyAnimatorManager);
        //bTurning = false;
       // bTurnEnd = false;
        enemyManager.NavDisableAgent();
        //enemyManager.SetAttackState(EnemyStates.JUMP_ATTACK);
        enemyManager.isPreformingAttackAction = true;
       
    }

    public bool CanUseSkill(Transform self, Transform target)
    {
        Vector3 targetDirection = target.position - self.position;
        float viewableAngle = Vector3.SignedAngle(targetDirection, self.forward, Vector3.up);
        if (Vector3.Dot(self.forward, targetDirection) < 0)
            return true;
        //if ((viewableAngle > 0 && viewableAngle <= 180) || viewableAngle < -0 && viewableAngle >= -180)
        //    return true;
        return false;
    }

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        if (!hasPerformedTurnAttack)
        {
            enemyManager.currentRecoveryTime = currentRecoverTimer;
            enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn_Attack", true);
            hasPerformedTurnAttack = true;//这个变量要等动画播放完毕 才可以置为False 不然回到CombaStanceState 就立刻重置了
            return combatStanceState;
        }
        return this;
    }


    public override void OnExit(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        //enemyManager.SetAttackState(EnemyStates.NONE);
    }
}