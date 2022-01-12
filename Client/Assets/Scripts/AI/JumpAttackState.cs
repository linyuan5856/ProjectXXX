using System.Collections;
using UnityEngine;

public class JumpAttackState : State
{
    public float MinJumpDistance = 5f;
    public float MaxJumpDistance = 7f;
    public PursueTargetState pursueTargetState;
    public AnimationCurve HeightCurve;
    public float JumpSpeed = 2;
    public float currentRecoverTimer = 3;
    private bool bJumping;
    private bool bJumpEnd;
    
    public override void OnEnter(EnemyManager enemyManager, EnemyStats enemyStats,
        EnemyAnimatorManager enemyAnimatorManager)
    {
        base.OnEnter(enemyManager, enemyStats, enemyAnimatorManager);
        bJumping = false;
        bJumpEnd = false;
        enemyManager.NavDisableAgent();
        enemyManager.SetAttackState(EnemyStates.JUMP_ATTACK);
        enemyManager.isPreformingAttackAction = true;
        enemyManager.currentRecoveryTime = currentRecoverTimer;
        enemyAnimatorManager.EnemyPlayTargetAnimationWithoutFade("Jump_Attack", true);
    }

    public bool CanUseSkill(Transform self, Transform target)
    {
        float distance = Vector3.Distance(self.position, target.position);
        return distance >= MinJumpDistance && distance <= MaxJumpDistance;
    }

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        if (!bJumping)
            StartCoroutine(Jump(enemyManager.transform, enemyManager.currentTarget.transform));
        if (bJumpEnd)
            return pursueTargetState;
        return this;
    }

    private IEnumerator Jump(Transform self, Transform target)
    {
        bJumping = true;
        Vector3 startingPosition = self.position;
        var offset = (target.position - startingPosition).normalized*2;
        offset = new Vector3(offset.x, 0f, offset.z);
        for (float time = 0; time < 1; time += Time.deltaTime * JumpSpeed)
        {
            self.transform.position = Vector3.Lerp(startingPosition, target.position-offset, time) +
                                      Vector3.up * HeightCurve.Evaluate(time);
            self.transform.rotation = Quaternion.Slerp(self.rotation,
                Quaternion.LookRotation(target.transform.position - self.position), time);
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);
        bJumpEnd = true;
    }

    public override void OnExit(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        enemyManager.SetAttackState(EnemyStates.NONE);
    }
}