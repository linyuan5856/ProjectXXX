using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    InputHandler inputHandler;
    Animator anim;
    PlayerLocomotion playerLocomotion;
    PlayerStats playerStats;

    public bool isInteracting;

    [Header("Player Flags")]
    public bool isSprinting;
    public bool isInAir;
    public bool isGrounded;
    public bool canDoCombo;
    public bool isUsingRightHand;
    public bool isUsingLeftHand;
    public bool isInvulnerable;

    //[SerializeField] 
    private float freeAnimDuring = 0.1f;
    private bool bPlayHitAnim;
    private float time;
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
        //cameraHandler = CameraHandler.singleton;
        //cameraController = GetComponentInChildren<CameraController>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerStats = GetComponent<PlayerStats>();
    }

   

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;

        isInteracting = anim.GetBool("isInteracting");
        canDoCombo = anim.GetBool("canDoCombo");
        isUsingRightHand = anim.GetBool("isUsingRightHand");
        isUsingLeftHand = anim.GetBool("isUsingLeftHand");
        isInvulnerable = anim.GetBool("isInvulnerable");
        anim.SetBool("isDead", playerStats.isDead);
        anim.SetBool("isBlocking", isBlocking);
        inputHandler.TickInput(delta);
        playerLocomotion.HandleRollingAndSprinting(delta);
        playerStats.RegenerateStamina();

        if (bPlayHitAnim)
        {
            time += delta;
            if (time>=freeAnimDuring)
            {
                time = 0;
                bPlayHitAnim = false;
                anim.speed = 1.0f;
            }
        }
      
    }
    private void FixedUpdate()
    {
        float delta = Time.deltaTime;
        playerLocomotion.HandleMovement(delta); 
        playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);

    }

    private void LateUpdate()
    {
        inputHandler.rollFlag = false;
        inputHandler.sprintFlag = false;
        inputHandler.rb_Input = false;
        inputHandler.rt_Input = false;
        inputHandler.lt_Input = false;
        inputHandler.d_Pad_Up = false;
        inputHandler.d_Pad_Down = false;
        inputHandler.d_Pad_Left = false;
        inputHandler.d_Pad_Right = false;
        isSprinting = inputHandler.b_Input;

       // float delta = Time.deltaTime;

        //if (cameraController != null)
        //{
        //    //cameraHandler.FollowTarget(delta);
        //    cameraController.HandleCameraRotation(inputHandler.mouseX, inputHandler.mouseY);
        //}

        if (isInAir)
        {
            playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime;
        }
    }

    
    public override void OnAttack()
    {
        base.OnAttack();
        bPlayHitAnim = true;
        if (Mathf.Approximately(time, 0f))
        {
            anim.speed = 0f;
        }
    }
}
