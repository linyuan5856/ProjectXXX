using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTargetState :State 
{
    // Start is called before the first frame update
    public CombatStanceState combatStanceState;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        enemyAnimatorManager.anim.SetFloat("Vertical", 0);
        enemyAnimatorManager.anim.SetFloat("Horizontal", 0);

        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        float viewableAngle = Vector3.SignedAngle(targetDirection, enemyManager.transform.forward, Vector3.up);

        if (enemyManager.isInteracting)
            return this;

        if(viewableAngle > 0 && viewableAngle <= 180 && !enemyManager.isInteracting)
        {
            enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Left", true);
            Debug.Log("左后");
            return combatStanceState;
        }
        else if(viewableAngle < -0 && viewableAngle >= -180 && !enemyManager.isInteracting)
        {
            enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Right", true);
            Debug.Log("右后");
            return combatStanceState;
        }
        else if (viewableAngle <= -60 && viewableAngle >= -104 && !enemyManager.isInteracting)
        {
            enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Right", true);
            Debug.Log("右");
            return combatStanceState;
        }
        else if (viewableAngle >= 60 && viewableAngle <= 104 && !enemyManager.isInteracting)
        {
            enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Left", true);
            Debug.Log("左");
            return combatStanceState;
        }

        return combatStanceState;
    }
}
