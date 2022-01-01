using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushState : State
{
    // Start is called before the first frame update
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        return this;
    }
}
