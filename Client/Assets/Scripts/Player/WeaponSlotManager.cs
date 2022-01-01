using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerManager playerManager;
    PlayerInventory playerInventory;

    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;

    public DamageCollider leftHandDamageCollider;
    public DamageCollider rightHandDamageCollider;

    public WeaponItem attackingWeapon ;

    Animator animator;

    PlayerStats playerStats;

    private void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
        playerInventory = GetComponentInParent<PlayerInventory>();
        animator = GetComponent<Animator>();
        playerStats = GetComponentInParent<PlayerStats>();

        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponSlot;
            }
            else if (weaponSlot.isRightHandSlot)
            {
                rightHandSlot = weaponSlot;
            }
    
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if (isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
            LoadLeftWeaponDamageCollider();

            #region Handle Weapon Idle Animation
            if (weaponItem != null)
            {
                animator.CrossFade(weaponItem.left_Hand_Idle, 0.2f);
            }
            else
            {
                animator.CrossFade("Left Arm Empty", 0.2f);
            }
            #endregion
        }
        else
        {
            rightHandSlot.LoadWeaponModel(weaponItem);
            LoadRightWeaponDamageCollider();

            #region Handle Weapon Idle Animation
            if (weaponItem != null)
            {
                animator.CrossFade(weaponItem.right_Hand_Idle, 0.2f);
            }
            else
            {
                animator.CrossFade("Right Arm Empty", 0.2f);
            }
            #endregion
        }
    }

    #region Handle Weapon's Damage Collider
    private void LoadLeftWeaponDamageCollider()
    {
        leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        if(leftHandDamageCollider != null)
        leftHandDamageCollider.currentWeaponDamage = playerInventory.leftWeapon.baseDamage;
    }

    private void LoadRightWeaponDamageCollider()
    {
        rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        if(rightHandDamageCollider != null)
        rightHandDamageCollider.currentWeaponDamage = playerInventory.rightWeapon.baseDamage;
    }

    public void OpenDamageCollider()
    {
        if (playerManager.isUsingRightHand)
        {
            rightHandDamageCollider.EnableDamageCollider();
        }
        else if (playerManager.isUsingLeftHand)
        {
            leftHandDamageCollider.EnableDamageCollider();
        }
    }
        

    public void CloseDamageCollider()
    {
        if (playerManager.isUsingRightHand)
        {
            rightHandDamageCollider.DisableDamageCollider();
        }
        else if (playerManager.isUsingLeftHand)
        {
            leftHandDamageCollider.DisableDamageCollider();
        }
    }

    #endregion

    #region Handle Weapon's Stamina Drainage
    public void DrainStaminalLightAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
    }

    public void DrainStaminalHeavyAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
    }
    #endregion
}
