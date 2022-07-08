using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D _playerRigidBody;
    PlayerControls _playerControls;

    [Header("Move Speed and Jump Height")]
    [Tooltip("adjusts height of jump")][SerializeField] float jumpHeight = 1f;
    [Tooltip("adjusts speed of movement")][SerializeField] float moveSpeed = 1f;


    private void Awake()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();

        _playerControls.Player.Move.performed += Move;
        _playerControls.Player.Jump.performed += Jump;
    }


    private void OnDisable()
    {
        _playerControls.Disable();
    }


    private void Move(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }


    private void Jump(InputAction.CallbackContext context)
    {
        _playerRigidBody.AddForce(Vector2.up * jumpHeight);
    }
}
