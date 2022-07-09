using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D _playerRigidBody;
    BoxCollider2D _playerBoxCollider;
    PlayerControls _playerControls;
    float _moveInputXValue;    // x value returned from Vector2 when player inputs move action


    [Header("Move Speed and Jump Height")]
    [Tooltip("adjusts height of jump")][SerializeField] float jumpHeight = 1f;
    [Tooltip("adjusts speed of movement")][SerializeField] float moveSpeed = 1f;

    [SerializeField] LayerMask platformLayerMask;  // layermask for raycast to detect 
    

    private void Awake()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerBoxCollider = GetComponent<BoxCollider2D>();
    }


    private void OnEnable()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();

        _playerControls.Player.Jump.performed += Jump;
    }


    private void Update()
    {
        _moveInputXValue = _playerControls.Player.Move.ReadValue<Vector2>().x;

    }


    private void FixedUpdate()
    {
        Move();
    }


    private void OnDisable()
    {
        _playerControls.Disable();
    }


    /// <summary>
    /// Called in FixedUpdate, takes in the players movinput and applies force
    /// to player based on that input, allows for left and right movement
    /// </summary>
    private void Move()
    {
        Vector2 processedMoveVector = new Vector2(_moveInputXValue, 0) * moveSpeed;
        _playerRigidBody.AddForce(processedMoveVector * Time.deltaTime, ForceMode2D.Force);
    }


    /// <summary>
    /// called any time the jump input action is performed. Applies upward force
    /// to the players rigidbody
    /// </summary>
    /// <param name="context"></param>
    private void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            _playerRigidBody.AddForce(Vector2.up * jumpHeight);
           
        }
    }


    /// <summary>
    /// Called in Jump, utilizes raycast and layermasking to check if the player
    /// is touching a layer that they can jump on.
    /// (for now, "platforms")
    /// </summary>
    /// <returns>bool true or false</returns>
    private bool IsGrounded()
    {
        float extraHeightTest = .02f;
        RaycastHit2D raycastHit = Physics2D.Raycast(_playerBoxCollider.bounds.center, Vector2.down, _playerBoxCollider.bounds.extents.y + extraHeightTest, platformLayerMask);

      
        return raycastHit.collider != null;
    }


}
