using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterManager hitCharacterManager;
    Collider damageCollider;
    private CameraManager cameraManager;

    public int currentWeaponDamage = 5;
    GameObject owner;
    float lastTime;
    private void Awake()
    {
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
        cameraManager = GetComponent<CameraManager>();
        owner = damageCollider.gameObject;
        
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
        //Debug.Log("dakai");
    }

    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (Time.time - lastTime > 0.5f)
        {
            if (collision.tag == "Player")
            {
                //怪物打玩家
                if (owner.tag == "EnemyWeapon")
                {
                    PlayerStats playerStats = collision.GetComponentInParent<PlayerStats>();
                    CharacterManager playercharacterManager = collision.GetComponentInParent<CharacterManager>();//玩家
                    BlockingCollider shield = collision.GetComponentInParent<CharacterManager>().GetComponentInChildren<BlockingCollider>();
                    playercharacterManager.isInteracting = true;
                    hitCharacterManager.OnAttack();
                    if (playercharacterManager != null)
                    {
                        if (playercharacterManager.isParrying)
                        {
                            //Debug.Log(characterManager.GetComponentInChildren<AnimatorManager>());
                            hitCharacterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Parried", true);
                            lastTime = Time.time;
                            return;
                        }
                        else if (shield != null && playercharacterManager.isBlocking)
                        {
                            float physicalDamageAfterBlock = currentWeaponDamage - (currentWeaponDamage * shield.blockingPhysicalDamageAbsorption) / 100;

                            if (playerStats != null)
                            {
                                playerStats.TakeDamage(Mathf.RoundToInt(physicalDamageAfterBlock), "Block_Guard");
                                lastTime = Time.time;
                                return;
                            }
                        }
                        else if (playerStats != null)
                        {
                            EnemyManager manager = (EnemyManager)hitCharacterManager;
                            
                            if (manager.AttackState == EnemyStates.JUMP_ATTACK)
                            {
                                Shake(0);
                                playerStats.TakeDamage(currentWeaponDamage, "Damage_02");
                                lastTime = Time.time;
                                return;
                            }
                            else
                                playerStats.TakeDamage(currentWeaponDamage);
                                lastTime = Time.time;
                                return;

                        }
                    }

                }
            }

            else if (collision.tag == "Enemy")
            {
                //玩家打怪物
                if (owner.tag == "PlayerWeapon")
                {
                    //EnemyStats enemyStats = collision.GetComponentInParent<EnemyStats>();
                    CharacterManager enemycharacterManager = collision.GetComponentInParent<CharacterManager>();
                    //BlockingCollider shield = collision.GetComponentInParent<CharacterManager>().GetComponentInChildren<BlockingCollider>();
                    //Shake(0);
                    hitCharacterManager.OnAttack();
                    enemycharacterManager?.OnBeHit(currentWeaponDamage);
                    //if (enemycharacterManager != null)
                    //{
                    //    if (enemycharacterManager.isParrying)
                    //    {
                    //        hitCharacterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Parried", true);
                    //        lastTime = Time.time;
                    //        return;
                    //    }
                    //    else if (enemyStats != null)
                    //    {
                    //        enemyStats.TakeDamage(currentWeaponDamage);
                    //        lastTime = Time.time;
                    //        return;
                    //    }
                    //}
                }
            }
        }
            
    }

     private void Shake(int a)
     {
        Debug.Log("准备震动"); 
        cameraManager.ShakeScreen(a);
     } 

   
}
