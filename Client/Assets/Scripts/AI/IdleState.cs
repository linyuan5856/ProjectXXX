using UnityEngine;

public class IdleState : State
{
    public PursueTargetState pursueTargetState;
    public JumpAttackState jumpAttackState;
    public LayerMask detectionLayer;
    private bool jumpOrAttack;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);

        var min = enemyManager.minimumDetectionAngle;
        var max = enemyManager.maximumDetectionAngle;

        foreach (var collider in colliders)
        {
            CharacterStats characterStats = collider.transform.GetComponent<CharacterStats>();
            if (characterStats == null) continue;
            Vector3 targetDirection = characterStats.transform.position - transform.position;
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

            if (!(viewableAngle > min) || !(viewableAngle < max)) continue;
            enemyManager.currentTarget = characterStats;
            break;
        }

        if (enemyManager.currentTarget != null)
        {
            RollForJumpChance();
            if (jumpOrAttack)
            {
                jumpOrAttack = false;
                bool canUseJumpAttack = jumpAttackState.CanUseSkill(enemyManager.transform, enemyManager.currentTarget.transform);
                if (canUseJumpAttack)
                    return jumpAttackState;

                else
                    return pursueTargetState;
            }
            else
                return pursueTargetState;
        }
        return this;
    }

    private void RollForJumpChance()
    {
        float jumpChance = Random.Range(0, 100);
        if (jumpChance > 30)
            jumpOrAttack = true;
        else
            jumpOrAttack = false;
    }
}