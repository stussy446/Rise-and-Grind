using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
    Animator animator;
    bool verticalCamera = true;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void SwitchState()
    {
        if (verticalCamera)
        {
            animator.Play("Horizontal Camera");
        }
        else
        {
            animator.Play("Vertical Camera");
        }

        verticalCamera = !verticalCamera;
    }
}


