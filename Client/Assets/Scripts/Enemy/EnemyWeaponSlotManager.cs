using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponSlotManager : MonoBehaviour
{
    private EnemyStats enemyStats;
    // Start is called before the first frame update
    public WeaponItem rightHandWeapon;
    public WeaponItem leftHandWeapon;

    public WeaponItem attackingWeapon;
    
    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;

    DamageCollider leftHandDamageCollider;
    DamageCollider rightHandDamageCollider;

    private void Awake()
    {
        enemyStats = GetComponentInParent<EnemyStats>();
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
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

    private void Start()
    {
        LoadWeaponOnBothHands(); 
    }
    public void LoadWeaponOnSlot(WeaponItem weapon, bool isLeft)
    {
        if (isLeft)
        {
            //leftHandSlot.currentWeapon = weapon;
            leftHandSlot.LoadWeaponModel(weapon);
            LoadWeaponDamageCollider(true);
        }
        else
        {
            //rightHandSlot.currentWeapon = weapon;
            rightHandSlot.LoadWeaponModel(weapon);
            LoadWeaponDamageCollider(false);
        }
    }

    public void LoadWeaponOnBothHands()
    {
        if (rightHandWeapon != null)
        {
            LoadWeaponOnSlot(rightHandWeapon, false);
        }
        if (leftHandWeapon != null)
        {
            LoadWeaponOnSlot(leftHandWeapon, true);
        }
    }

    public void LoadWeaponDamageCollider(bool isLeft)
    {
        if (isLeft)
        {
            leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
            //leftHandDamageCollider.characterManager = GetComponentInParent<CharacterManager>();
        }
        else
        {
           rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
           rightHandDamageCollider.hitCharacterManager = GetComponentInParent<CharacterManager>();
           //Debug.Log(rightHandDamageCollider);
        }
        
    }

    public void OpenDamageCollider()
    {
        rightHandDamageCollider.EnableDamageCollider();
        //Debug.Log("dakai");
    }

    public void CloseDamageCollider()
    {
        rightHandDamageCollider.DisableDamageCollider();
    }

    public void EnableCombo()
    {
        //anim.SetBool("canDoCombo", true);
    }

    public void DisableCombo()
    {
        //anim.SetBool("canDoCombo", false);
    }
    
    #region Handle Weapon's Stamina Drainage
    public void DrainStaminalLightAttack()
    {
        enemyStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
    }

    public void DrainStaminalHeavyAttack()
    {
        enemyStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
    }
    #endregion
}
