using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isInteracting;

    [Header ("Combat Colliders")]
    public CriticalDamageCollider backStabCollider;
    public CriticalDamageCollider riposteCollider;

    [Header("Combat Flags")]
    public bool canBeRiposted;
    public bool canBeParried;
    public bool isParrying;
    public bool isBlocking;

    [Header("Movement Flags")]
    public bool isRotatingWithRootMotion;

    public int pendingCriticalDamage;

    public virtual void OnAttack()
    {
    }

    public virtual void OnBeHit(int damage)
    {

    }
}
