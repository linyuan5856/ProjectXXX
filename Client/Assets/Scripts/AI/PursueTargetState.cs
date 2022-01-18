using UnityEngine;

public class PursueTargetState : State
{
    public CombatStanceState combatStanceState;
    public CircleState circleState;
    public RotateTowardsTargetState rotateTowardsTargetState;
    public JumpAttackState jumpAttackState;
    public float distanceFromTarget;
    private bool jumpOrAttack;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats,
        EnemyAnimatorManager enemyAnimatorManager)
    {
        distanceFromTarget =
            Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

        if (enemyManager.isInteracting)
            return this;

        HandleRotateTowardsTarget(enemyManager);
        if (enemyStats.currentStamina <= 10)
            return circleState;

        RollForJumpChance();
        if (jumpOrAttack)
        {
            jumpOrAttack = false;
            bool canUseJumpAttack = jumpAttackState.CanUseSkill(enemyManager.transform, enemyManager.currentTarget.transform);
            if (canUseJumpAttack) return jumpAttackState;
            return this;
        }

        if (distanceFromTarget > enemyManager.maximumAttackRange)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
            enemyAnimatorManager.anim.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
            enemyManager.NavSetDestination(enemyManager.currentTarget.transform.position);
            return this;
        }

        return combatStanceState;
    }

    private void HandleRotateTowardsTarget(EnemyManager enemyManager)
    {
        var pos = enemyManager.currentTarget.transform.position;
        enemyManager.NavSetDestination(new Vector3(pos.x, 0f, pos.z));
        enemyManager.transform.rotation = Quaternion.Slerp(enemyManager.transform.rotation,
            enemyManager.transform.rotation, enemyManager.rotationSpeed / Time.deltaTime);
    }

    private void RollForJumpChance()
    {
        float jumpChance = Random.Range(0, 100);
        jumpOrAttack = jumpChance > 60;
    }
}