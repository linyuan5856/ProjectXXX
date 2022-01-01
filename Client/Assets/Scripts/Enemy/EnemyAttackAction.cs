using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="A.I/Enemy Actions/Attack Action")]
public class EnemyAttackAction : EnemyActions
{
    // Start is called before the first frame update
    public bool canCombo;
    public EnemyAttackAction comboAction;

    public int attackScore;
    public float recoveryTime ;

    public float maximumAttackAngle;
    public float minimumAttackAngle;

    public float minimumDistanceNeededToAttack;
    public float maximumDistanceNeededToAttack;
}
