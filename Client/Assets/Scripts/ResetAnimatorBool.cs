﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimatorBool : StateMachineBehaviour
{

    public string targetBool;
    public bool status;

    public string isRotatingWithRootMotion = "isRotatingWithRootMotion";
    public bool isRotatingWithRootMotionStatus = false;
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.SetBool(targetBool, status);
       animator.SetBool(isRotatingWithRootMotion, isRotatingWithRootMotionStatus);
    }


    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    animator.SetBool("isInteracting", false);
    //}

   
}
