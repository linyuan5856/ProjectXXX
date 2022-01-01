using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Item/Weapon Item")]
public class WeaponItem : Item
{
    // Start is called before the first frame update
    public GameObject modelPrefab;
    public bool isUnarmed;

    [Header("Damage")]
    public int baseDamage;
    public int criticalDamageMultiplier;

    [Header("Absorption")]
    public float physicalDamageAbsorption;

    [Header("Idle Animations")]
    public string right_Hand_Idle;
    public string left_Hand_Idle;

    [Header("One Handed Attack Animations")]
    public string OH_Light_Attack_1;
    public string OH_Light_Attack_2;
    public string OH_Light_Attack_3;
    public string OH_Heavy_Attack_1;

    [Header("Weapon Art")]
    public string weapon_art;

    [Header("Stamina Costs")]
    public int baseStamina;
    public float lightAttackMultiplier;
    public float heavyAttackMultiplier;

    [Header("Weapon Type")]
    public bool isShieldWeapon;
}
