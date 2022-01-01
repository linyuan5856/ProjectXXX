using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : AnimatorManager
{
    PlayerManager playerManager;
    PlayerStats playerStats;
    InputHandler inputHandler;
    PlayerLocomotion playerLocomotion;
    //CameraManager cameraManager;
    int vertical;
    int horizontal;
    public bool canRotate;

    public void Init()
    {
        playerManager = GetComponentInParent<PlayerManager>();
        playerStats = GetComponentInParent<PlayerStats>();
        anim = GetComponent<Animator>();
        inputHandler = GetComponentInParent<InputHandler>();
        playerLocomotion = GetComponentInParent<PlayerLocomotion>();
        vertical = Animator.StringToHash("Vertical");
        horizontal = Animator.StringToHash("Horizontal");
        //cameraManager = GetComponentInParent<CameraManager>();
    }

    public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement, bool isSprinting)

    {
        #region Vertiacl
        float v = 0;

        if(verticalMovement > 0 && verticalMovement < 0.55f)
        {
            v = 0.5f;
        }
        else if (verticalMovement > 0.55f)
        {
            v = 1;
        }
        else if (verticalMovement <0 && verticalMovement > -0.55f)
        {
            v = -0.5f;
        }
        else if(verticalMovement < -0.55f)
        {
            v = -1;
        }
        else
        {
            v = 0;
        }
        #endregion

        #region Horizontal
        float h = 0;

        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            h = 0.5f;
        }
        else if (horizontalMovement > 0.55f)
        {
            h = 1;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            h = -0.5f;
        }
        else if (horizontalMovement < -0.55f)
        {
            h = -1;
        }
        else
        {
            h = 0;
        }
        #endregion

        if (isSprinting)
        {
            v = 2;
            h = horizontalMovement;
        }

        anim.SetFloat(vertical, v, 0.1f, Time.fixedDeltaTime);
        anim.SetFloat(horizontal, h, 0.1f, Time.fixedDeltaTime);
    }

   

    public void CanRotate()
    {
        canRotate = true;
    }

    public void StopRotation()
    {
        canRotate = false;
    }

    public void EnableCombo()
    {
        anim.SetBool("canDoCombo", true);
    }

    public void DisableCombo()
    {
        anim.SetBool("canDoCombo", false);
    }

    public void EnableIsInvulnerable()
    {
        anim.SetBool("isInvulnerable", true);
    }

    public void DisableIsInvulnerable()
    {
        anim.SetBool("isInvulnerable", false);
    }

    public void EnableIsParrying()
    {
        playerManager.isParrying = true;
    }

    public void DisableIsParrying()
    {
        playerManager.isParrying = false;
    }

    public void EnableCanBeRiposted()
    {
        playerManager.canBeRiposted = true;
    }

    public void DisableCanBeRiposted()
    {
        playerManager.canBeRiposted = false;
    }

    public override void TakeCriticalDamageAnimationEvent()
    {
        playerStats.TakeDamageNoAnimation(playerManager.pendingCriticalDamage);
        playerManager.pendingCriticalDamage = 0;
    }
    //private void OnAnimatorMove()
    //{
    //    if (playerManager.isInteracting == false)
    //        return;

    //    float delta = Time.deltaTime;
    //    playerLocomotion.rigidbody.drag = 0;
    //    Vector3 deltaPosition = anim.deltaPosition;
    //    deltaPosition.y = 0;
    //    Vector3 velocity = deltaPosition / delta;
    //    playerLocomotion.rigidbody.velocity = velocity;
    //}
}
