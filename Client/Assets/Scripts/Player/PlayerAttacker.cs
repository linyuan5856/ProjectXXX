using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerAnimatorManager animatorHandler;
    PlayerEquipmentManager playerEquipmentManager;
    InputHandler inputHandler;
    WeaponSlotManager weaponSlotManager;
    PlayerStats playerStats;
    PlayerManager playerManager;
    PlayerInventory playerInventory;
    
    public string lastAttack;

    Transform myTransform;

    LayerMask backStabLayer = 1 << 12;
    LayerMask riposterLayer = 1 << 13;


    public void Awake()
    {
        animatorHandler = GetComponent<PlayerAnimatorManager>();
        playerEquipmentManager = GetComponent<PlayerEquipmentManager>();
        inputHandler = GetComponentInParent<InputHandler>();
        weaponSlotManager = GetComponent<WeaponSlotManager>();
        playerStats = GetComponentInParent<PlayerStats>();
        playerManager = GetComponentInParent<PlayerManager>();
        playerInventory = GetComponentInParent<PlayerInventory>();
        myTransform =playerManager.transform;
       
    }

    public void HandleLightWeaponCombo(WeaponItem weapon)
    {
        if (playerStats.currentStamina <= 0)
            return;

        if (playerStats.currentStamina < Mathf.RoundToInt(weaponSlotManager.attackingWeapon.baseStamina * weaponSlotManager.attackingWeapon.lightAttackMultiplier))
            return;
        
        if (inputHandler.comboFlag == 1)
        {
            animatorHandler.anim.SetBool("canDoCombo", false);

            if (lastAttack == weapon.OH_Light_Attack_1)
            {
                animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_2, true);
                lastAttack = weapon.OH_Light_Attack_2;
                
            }
        }
        if (inputHandler.comboFlag == 2)
        {
            animatorHandler.anim.SetBool("canDoCombo", false);

            if (lastAttack == weapon.OH_Light_Attack_2)
            {
                animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_3, true);
               
                lastAttack = null;
            }
        }

    }

    public void Move()
    {
       
        StartCoroutine(PosChange(0.4f,0.005f));
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        if (playerStats.currentStamina <= 0)
            return;
        weaponSlotManager.attackingWeapon = weapon;
        if (playerStats.currentStamina < Mathf.RoundToInt(weaponSlotManager.attackingWeapon.baseStamina * weaponSlotManager.attackingWeapon.lightAttackMultiplier))
            return;
        animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
        lastAttack = weapon.OH_Light_Attack_1;
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {
        if (playerStats.currentStamina <= 0)
            return;

        weaponSlotManager.attackingWeapon = weapon;
        if (playerStats.currentStamina < Mathf.RoundToInt(weaponSlotManager.attackingWeapon.baseStamina * weaponSlotManager.attackingWeapon.heavyAttackMultiplier))
            return;
        animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
        lastAttack = weapon.OH_Light_Attack_1;
    }

    public void HandleLBAction()
    {
        PerformLBBlockingAction();
    }

    public void HandleLTAction()
    {
        if (playerInventory.leftWeapon.isShieldWeapon)
        {
            PerformLTWeapon(true);
        }
    }

    private void PerformLBBlockingAction()
    {
        if (playerManager.isInteracting)
            return;

        if (playerManager.isBlocking)
            return;

        animatorHandler.PlayTargetAnimationWithoutFade("Block_Start", false);
        playerEquipmentManager.OpenBlockingCollider();
        playerManager.isBlocking = true;
    }

    private void PerformLTWeapon(bool isLeftWeapon)
    {
        if (playerManager.isInteracting)
            return;

        if (isLeftWeapon)
        {
            animatorHandler.PlayTargetAnimation(playerInventory.leftWeapon.weapon_art, true);
        }
    }

    public void AttemptBackStabOrRipose(WeaponItem weapon)
    {
        if (playerStats.currentStamina <= 0)
            return;

        weaponSlotManager.attackingWeapon = weapon;
        if (playerStats.currentStamina < Mathf.RoundToInt(weaponSlotManager.attackingWeapon.baseStamina * weaponSlotManager.attackingWeapon.lightAttackMultiplier))
            return;

        RaycastHit hit;

        if(Physics.Raycast(inputHandler.criticalAttackRayCastStartPoint.position, transform.TransformDirection(Vector3.forward), out hit, 0.5f, backStabLayer))
        {
            CharacterManager enemyCharacterManager = hit.transform.gameObject.GetComponentInParent<CharacterManager>();
            DamageCollider rightWeapon = weaponSlotManager.rightHandDamageCollider;

            if(enemyCharacterManager != null)
            {
                playerManager.transform.position = enemyCharacterManager.backStabCollider.criticalDamageStandPoint.position;
                Vector3 rotationDirection = playerManager.transform.root.eulerAngles;
                rotationDirection = hit.transform.position - playerManager.transform.position;
                rotationDirection.y = 0;
                rotationDirection.Normalize();
                Quaternion tr = Quaternion.LookRotation(rotationDirection);
                Quaternion targetRotation = Quaternion.Slerp(playerManager.transform.rotation, tr, 500 * Time.deltaTime);
                playerManager.transform.rotation = targetRotation;

                int criticalDamage = playerInventory.rightWeapon.criticalDamageMultiplier * rightWeapon.currentWeaponDamage;
                enemyCharacterManager.pendingCriticalDamage = criticalDamage;
                //playerStats.TakeStaminaDamage(Mathf.RoundToInt(weaponSlotManager.attackingWeapon.baseStamina * weaponSlotManager.attackingWeapon.lightAttackMultiplier));
                animatorHandler.PlayTargetAnimation("Back Stab", true);
                enemyCharacterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Back Stabbed", true);
            }
        }
        else if(Physics.Raycast(inputHandler.criticalAttackRayCastStartPoint.position, transform.TransformDirection(Vector3.forward), out hit, 0.7f, riposterLayer))
        {
            CharacterManager enemyCharacterManager = hit.transform.gameObject.GetComponentInParent<CharacterManager>();
            DamageCollider rightWeapon = weaponSlotManager.rightHandDamageCollider;

            if (enemyCharacterManager != null && enemyCharacterManager.canBeRiposted)
            {
                playerManager.transform.position = enemyCharacterManager.riposteCollider.criticalDamageStandPoint.position;

                Vector3 rotationDirection = playerManager.transform.root.eulerAngles;
                rotationDirection = hit.transform.position - playerManager.transform.position;
                rotationDirection.y = 0;
                rotationDirection.Normalize();
                Quaternion tr = Quaternion.LookRotation(rotationDirection);
                Quaternion targetRotation = Quaternion.Slerp(playerManager.transform.rotation, tr, 500 * Time.deltaTime);
                playerManager.transform.rotation = targetRotation;

                int criticalDamage = playerInventory.rightWeapon.criticalDamageMultiplier * rightWeapon.currentWeaponDamage;
                enemyCharacterManager.pendingCriticalDamage = criticalDamage;

                animatorHandler.PlayTargetAnimation("Back Stab", true);
                enemyCharacterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Back Stabbed", true);
            }
        }
    }


    IEnumerator PosChange(float time ,float dis)
    {
        float curtime = 0;
        int count = 0;
        while (true)
        {
            if (count > 10000)
            {
                break;
            }
            if (curtime >= time)
            {
                break;
            }
            myTransform.localPosition += myTransform.forward * dis;
            yield return null;
            curtime += Time.deltaTime;
            count++;
        }
    }


}
