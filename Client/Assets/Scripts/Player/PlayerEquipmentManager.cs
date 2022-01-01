using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    InputHandler inputHandler;
    PlayerInventory playerInventory;
    public BlockingCollider blockingCollider;

    private void Awake()
    {
       inputHandler = GetComponentInParent<InputHandler>();
       playerInventory = GetComponentInParent<PlayerInventory>();
    }

    public void OpenBlockingCollider()
    {
        blockingCollider.SetColliderDamageAbsorption(playerInventory.leftWeapon);
        blockingCollider.EnableBlockingCollider();
    }

    public void CloseBlockingCollider()
    {
        blockingCollider.DisableBlockingCollider();
    }
}
