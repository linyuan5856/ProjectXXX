using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyStates { NONE, ATTACK, JUMP_ATTACK}
public class EnemyManager : CharacterManager
{
    // Start is called before the first frame update
    EnemyLocomotionManager enemyLocomotionManager;
    EnemyAnimatorManager enemyAnimatorManager;
    EnemyStats enemyStats;

    private EnemyStates attackState;
    private NavMeshAgent navmeshAgent;
    public State currentState;
    public CharacterStats currentTarget;
    public Rigidbody enemyRigidbody;
    public EnemyStates AttackState => attackState;
    public BeHitState beHitState;  
    public float stoppingDistance;
    public float rotationSpeed = 15;
    public float maximumAttackRange;     //招架选择攻击状态的范围
   

    //public bool isInteracting;
    public bool canRotate;

    //public EnemyAttackAction[] enemyAttacks;
    //public EnemyAttackAction currentAttack;
    [Header("Combat Flags")]
    public bool canDoCombo;

    [Header("A.I Settings")]
    public float detectionRadius = 20;
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;
    public float currentRecoveryTime;//攻击冷却时间
   // public float combatStanceTime = 3;

    [Header("A.I Combat Settings")]
    public float strainValue;       //ai攻击耐力值
    public bool isPreformingAttackAction;
    public bool allowAIToPerformCombo;
    public float comboLikelyHood;    //连招概率

    public void Awake()
    {
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
        enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        enemyStats = GetComponent<EnemyStats>();
        enemyRigidbody = GetComponent<Rigidbody>();
        navmeshAgent = GetComponent<NavMeshAgent>();
        navmeshAgent.enabled = false;
    }

    private void Start()
    {
        enemyRigidbody.isKinematic = false;
    }

    public void Update()
    {
        HandleRecoveryTimer();
        HandleStateMachine();

        isInteracting =enemyAnimatorManager.anim.GetBool("isInteracting");
        canDoCombo = enemyAnimatorManager.anim.GetBool("canDoCombo");
        canRotate = enemyAnimatorManager.anim.GetBool("canRotate");
        enemyAnimatorManager.anim.SetBool("isDead", enemyStats.isDead);
        isRotatingWithRootMotion = enemyAnimatorManager.anim.GetBool("isRotatingWithRootMotion");
        enemyStats.RegenerateStamina();
    }
    
    public void NavDisableAgent()
    {
        navmeshAgent.enabled = false;
    }

    public void NavSetDestination(Vector3 pos)
    {
        navmeshAgent.enabled = true;
        navmeshAgent.SetDestination(pos);
    }
    
    private void HandleStateMachine()
    {
        if (currentState == null) return;
        State nextState = currentState.Tick(this, enemyStats, enemyAnimatorManager);
        if (nextState != currentState)
        {
            SwitchToNextState(nextState);
        }
        //if (currentState != null)
        //{
        //    State nextState = currentState.Tick(this, enemyStats, enemyAnimatorManager);
        //    if (nextState != currentState)
        //    {
        //        //Debug.Log((nextState));
        //        currentState.OnExit(this, enemyStats, enemyAnimatorManager);
        //        nextState.OnEnter(this, enemyStats, enemyAnimatorManager);
        //        SwitchToNextState(nextState);
        //    }
        //}
    }

    private void SwitchToNextState(State state)
    {
        if (state == null) return;
        currentState?.OnExit(this, enemyStats, enemyAnimatorManager);
        currentState = state;
        currentState.OnEnter(this, enemyStats, enemyAnimatorManager);
        //currentState = state;
    }

    private void HandleRecoveryTimer()
    {
        if (currentRecoveryTime > 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }

        if (currentRecoveryTime <= 0)
        {
            isPreformingAttackAction = false;
        }
    }

    public void SetAttackState(EnemyStates state)
    {
        attackState = state;
    }

    float lastTime;

    public override void OnBeHit(int currentWeaponDamage)
    {
        if (Time.time - lastTime < 0.5f) return;
        lastTime = Time.time;
        if (enemyStats != null)
        {
            enemyStats.TakeDamage(currentWeaponDamage);
            SwitchToNextState(beHitState);
        }

    }
}
  
