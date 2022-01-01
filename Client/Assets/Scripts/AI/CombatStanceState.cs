using UnityEngine;

public class CombatStanceState : State
{
    public AttackState attackState;
    public EnemyAttackAction[] enemyAttacks;
    public PursueTargetState pursueTargetState;
    public CircleState circleState;

    float verticalMovementValue = 0;
    float horizontalMovementValue = 0;
    public float distanceFromTarget;

    public override void OnEnter(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        base.OnEnter(enemyManager, enemyStats, enemyAnimatorManager);
        enemyAnimatorManager.anim.SetFloat("Vertical", 0);
        enemyAnimatorManager.anim.SetFloat("Horizontal", 0);
        enemyManager.NavDisableAgent();
    }
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats,
        EnemyAnimatorManager enemyAnimatorManager)
    {
        distanceFromTarget =
            Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        enemyAnimatorManager.anim.SetFloat("Vertical", verticalMovementValue, 0.2f, Time.deltaTime);
        enemyAnimatorManager.anim.SetFloat("Horizontal", horizontalMovementValue, 0.2f, Time.deltaTime);
        attackState.hasPerformedAttack = false;
        HandleRotateTowardsTarget(enemyManager);

        if (enemyManager.isInteracting)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical", 0);
            enemyAnimatorManager.anim.SetFloat("Horizontal", 0);
            return this;
        }

        if (distanceFromTarget > enemyManager.maximumAttackRange) 
            return pursueTargetState;

        if (enemyStats.currentStamina <= 50) 
            return circleState;

       

        if (enemyManager.currentRecoveryTime <= 0 && attackState.currentAttack != null)
            return attackState;
        else
        {
            GetNewAttack(enemyManager);
        }
       
        return this;
    }

    private void HandleRotateTowardsTarget(EnemyManager enemyManager)
    {
        Vector3 direction = enemyManager.currentTarget.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();

        if (direction == Vector3.zero) 
            direction = transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
        enemyManager.rotationSpeed / Time.deltaTime);
    }


    private void GetNewAttack(EnemyManager enemyManager)
    {
        Vector3 targetsDirection = enemyManager.currentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetsDirection, transform.forward);
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);

        int maxScore = 0;

        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];

            if (distanceFromTarget <= enemyAttackAction.maximumDistanceNeededToAttack &&
                distanceFromTarget >= enemyAttackAction.minimumDistanceNeededToAttack)
            {
                if (viewableAngle <= enemyAttackAction.maximumAttackAngle &&
                    viewableAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    maxScore += enemyAttackAction.attackScore;
                }
            }
        }

        int randomValue = Random.Range(0, maxScore);
        int temporaryScore = 0;

        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];

            if (distanceFromTarget <= enemyAttackAction.maximumDistanceNeededToAttack &&
                distanceFromTarget >= enemyAttackAction.minimumDistanceNeededToAttack)
            {
                if (viewableAngle <= enemyAttackAction.maximumAttackAngle &&
                    viewableAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    if (attackState.currentAttack != null)
                        return;

                    temporaryScore += enemyAttackAction.attackScore;

                    if (temporaryScore > randomValue)
                    {
                        attackState.currentAttack = enemyAttackAction;
                    }
                }
            }
        }
    }
}