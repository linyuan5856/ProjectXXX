using UnityEngine;

public class AttackState : State
{
    public RotateTowardsTargetState rotateTowardsTargetState;
    public CombatStanceState combatStanceState;
    public PursueTargetState pursueTargetState;
    public EnemyAttackAction currentAttack;

    bool willDoComboOnNextAttack = false;
    public bool hasPerformedAttack = false;

    public override void OnEnter(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        base.OnEnter(enemyManager, enemyStats, enemyAnimatorManager);
        enemyAnimatorManager.anim.SetFloat("Vertical", 0);
        enemyAnimatorManager.anim.SetFloat("Horizontal", 0);
        enemyManager.NavDisableAgent();
        enemyManager.SetAttackState(EnemyStates.ATTACK);
    }

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        RotateTowardsTargetWhileAttacking(enemyManager);
        if (enemyManager.isPreformingAttackAction)
            return this;

        if (distanceFromTarget > enemyManager.maximumAttackRange) 
            return pursueTargetState;
        
        if (willDoComboOnNextAttack && enemyManager.canDoCombo)
            AttackTargetWithCombo(enemyAnimatorManager, enemyManager);
        
        if (!hasPerformedAttack)
        {
            AttackTarget(enemyAnimatorManager, enemyManager);
            RollForComboChance(enemyManager);
        }

        if (willDoComboOnNextAttack && hasPerformedAttack)
            return this;

        return combatStanceState;
    }

    private void AttackTarget(EnemyAnimatorManager enemyAnimatorManager, EnemyManager enemyManager)
    {
        enemyManager.isPreformingAttackAction = true;
        enemyAnimatorManager.EnemyPlayTargetAnimation(currentAttack.actionAnimation, true);
        enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
        hasPerformedAttack = true;
    }


    private void AttackTargetWithCombo(EnemyAnimatorManager enemyAnimatorManager, EnemyManager enemyManager)
    {
        enemyManager.isPreformingAttackAction = true;
        willDoComboOnNextAttack = false;
        enemyAnimatorManager.EnemyPlayTargetAnimation(currentAttack.actionAnimation, true);
        enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
        currentAttack = null;
    }


    private void RotateTowardsTargetWhileAttacking(EnemyManager enemyManager)
    {
        if (enemyManager.canRotate && enemyManager.isInteracting)
        {
            Vector3 direction = enemyManager.currentTarget.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.zero) direction = transform.forward;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                enemyManager.rotationSpeed / Time.deltaTime);
        }
    }


    private void RollForComboChance(EnemyManager enemyManager)
    {
        float comboChance = Random.Range(0, 100);
        if (/*!enemyManager.allowAIToPerformCombo ||*/ !(comboChance <= enemyManager.comboLikelyHood))
            return;

        if (currentAttack.comboAction != null)
        {
            willDoComboOnNextAttack = true;
            currentAttack = currentAttack.comboAction;
        }
        else
        {
            willDoComboOnNextAttack = false;
            currentAttack = null;
        }
    }


    public override void OnExit(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        enemyManager.SetAttackState(EnemyStates.NONE);
    }
}