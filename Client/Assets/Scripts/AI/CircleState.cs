using UnityEngine;

public class CircleState : State
{
    public CombatStanceState combatStanceState;

    public float verticalMovementValue = 0;
    public float horizontalMovementValue = 0;
    public float distanceFromTarget;

    public override void OnEnter(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        base.OnEnter(enemyManager, enemyStats, enemyAnimatorManager);
        enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.2f, Time.deltaTime);
        enemyAnimatorManager.anim.SetFloat("Horizontal", 0, 0.2f, Time.deltaTime);
        enemyManager.NavDisableAgent();
    }

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        distanceFromTarget =
            Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        enemyManager.transform.LookAt(enemyManager.currentTarget.transform);
        enemyManager.transform.RotateAround(enemyManager.currentTarget.transform.position, Vector3.up,100 * Time.deltaTime / distanceFromTarget);
        DecideCirclingAction(enemyAnimatorManager);
        enemyAnimatorManager.anim.SetFloat("Vertical", verticalMovementValue, 0.2f, Time.deltaTime);
        enemyAnimatorManager.anim.SetFloat("Horizontal", horizontalMovementValue, 0.2f, Time.deltaTime);

        if (enemyStats.currentStamina > 50) 
            return combatStanceState;
        return this;
    }

    private void DecideCirclingAction(EnemyAnimatorManager enemyAnimatorManager)
    {
        WalkAroundTarget(enemyAnimatorManager);
    }

    private void WalkAroundTarget(EnemyAnimatorManager enemyAnimatorManager)
    {
        verticalMovementValue = Random.Range(0, 1);

        if (verticalMovementValue <= 1 && verticalMovementValue >= 0)
            verticalMovementValue = 1f;
        else if (verticalMovementValue >= -1 && verticalMovementValue < 0)
            verticalMovementValue = -1f;
        
        horizontalMovementValue = Random.Range(-1, 1);

        if (horizontalMovementValue <= 1 && horizontalMovementValue >= 0)
            horizontalMovementValue = 1f;
        else if (horizontalMovementValue >= -1 && horizontalMovementValue < 0)
            horizontalMovementValue = -1f;
    }
}