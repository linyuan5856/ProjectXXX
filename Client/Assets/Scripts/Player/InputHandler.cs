using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    public bool b_Input;
    public bool rb_Input;
    public bool rt_Input;
    public bool lb_Input;
    public bool lt_Input;
    public bool critical_Attack_Input;
    public bool d_Pad_Up;
    public bool d_Pad_Down;
    public bool d_Pad_Left;
    public bool d_Pad_Right;

    public bool rollFlag;
    public bool sprintFlag;
    public int comboFlag;
    public float rollInputTimer;

    public Transform criticalAttackRayCastStartPoint;

    PlayerControls inputActions;
    PlayerAttacker playerAttacker;
    PlayerInventory playerInventory;
    PlayerManager playerManager;
    PlayerAnimatorManager animatorHandler;
    BlockingCollider blockingCollider;

    Vector2 movementInput;
    Vector2 cameraInput;

    private void Awake()
    {
        playerAttacker = GetComponentInChildren<PlayerAttacker>();
        playerInventory = GetComponent<PlayerInventory>();
        playerManager = GetComponent<PlayerManager>();
        animatorHandler = GetComponentInChildren<PlayerAnimatorManager>();
        blockingCollider = GetComponentInChildren<BlockingCollider>();
        comboFlag = 0;
    }
    public void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            inputActions.PlayerActions.RB.performed += i => rb_Input = true;
            inputActions.PlayerActions.RT.performed += i => rt_Input = true;
            inputActions.PlayerActions.LB.performed += i => lb_Input = true;
            inputActions.PlayerActions.LB.canceled += i => lb_Input = false;
            inputActions.PlayerActions.LT.performed += i => lt_Input = true;
            inputActions.PlayerQuickSlots.DPadRight.performed += i => d_Pad_Right = true;
            inputActions.PlayerQuickSlots.DPadLeft.performed += i => d_Pad_Left = true;
            inputActions.PlayerActions.CriticalAttack.performed += i => critical_Attack_Input = true;

        }
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
        HandleRollInput(delta);
        HandleAttackInput(delta);
        HandleQuickSlotsInput();
        HandleCriticalAttackInput();
    }

    private void MoveInput(float delta)
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    private void HandleRollInput(float delta)
    {
        b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Performed;
       // print(b_Input);
        if (b_Input)
        {
            rollInputTimer += delta;
            sprintFlag = true;
        }
        else
        {
            if(rollInputTimer > 0 && rollInputTimer < 0.5f)
            {
                sprintFlag = false;
                rollFlag = true;
            }
            rollInputTimer = 0;
        }
    }

    private void HandleAttackInput(float delta)
    {
        //RB Input handles the RIGHT hand weapon's light attack;
        if (rb_Input)
        {
            if (playerInventory.rightWeapon != playerInventory.unarmedWeapon)
            {
                if (playerManager.canDoCombo)
                {
                   if(comboFlag == 1)
                    {
                        playerAttacker.HandleLightWeaponCombo(playerInventory.rightWeapon);
                        comboFlag = 2;
                       
                    }
                   else if (comboFlag == 2)
                    {
                 
                        playerAttacker.HandleLightWeaponCombo(playerInventory.rightWeapon);
                        comboFlag = 0;
                    }


                }
                else
                {
                    if (playerManager.isInteracting)
                        return;

                    if (playerManager.canDoCombo)
                        return;

                    animatorHandler.anim.SetBool("isUsingRightHand", true);
                    playerAttacker.HandleLightAttack(playerInventory.rightWeapon);
                    comboFlag =1;
                }
            } 
        }
        if (rt_Input)
        {
            playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
        }

        if (playerInventory.leftWeapon != playerInventory.unarmedWeapon)
        {
            if (lb_Input)
            {
                //Debug.Log("fangwei");
                playerAttacker.HandleLBAction();
            }
            else
            {
                playerManager.isBlocking = false;

                if (blockingCollider.blockingCollider.enabled)
                {
                    blockingCollider.DisableBlockingCollider();
                }
            }

            if (lt_Input)
            {
                playerAttacker.HandleLTAction();
            }
        }
    }

    private void HandleQuickSlotsInput()
    {
        

        if (d_Pad_Right)
        {
            playerInventory.ChangeRightWeapon();
        }
        else if (d_Pad_Left)
        {
            playerInventory.ChangeLeftWeapon();
        }
    }

    private void HandleCriticalAttackInput()
    {
        if (critical_Attack_Input)
        {
            critical_Attack_Input = false;
            playerAttacker.AttemptBackStabOrRipose(playerInventory.rightWeapon);
        }
    }

}

