using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D _playerRigidBody;
    BoxCollider2D _playerBoxCollider;
    PlayerControls _playerControls;
    float moveInputXValue;
    float _rotateInputValue;

    bool playerIsAttacking = false;
    bool canMove = true;
    bool beanTouched = false;
    bool goldenBeanTouched = false;
    RigidbodyConstraints2D startingConstraints;
    SoundManager soundManager;
    Animator playerAnimator;


    [Header("Movement")]
    [Tooltip("adjusts speed of movement")][SerializeField] float moveSpeed = 1f;
    [Tooltip("adjusts acceleration speed")][SerializeField] float acceleration = 1f;
    [Tooltip("adjusts decelleration speed")][SerializeField] float deccelaration = 1f;
    [Tooltip("adjusts how quickly velocity is applied")][SerializeField] float velPower = 1f;

    [Header("Friction")]
    [Tooltip("adjust how much player slides at end of movement")][SerializeField] float frictionAmount = 1f;


    [Header("Jumping")]
    [Tooltip("adjusts height of jump")][SerializeField] float jumpHeight = 1f;
    [Tooltip("adjusts height of golden bean boost")][SerializeField] float goldenHeight = 5f;
    [Tooltip("adjusts fall speed of jump")][SerializeField] float fallMultiplier = 2.5f;
    [Tooltip("adjusts speed of rotation")][SerializeField] float rotationSpeed = 1f;
    [Tooltip("adjusts how much shorter the jump is on tap vs hold")][SerializeField] float jumpCutMultiplier = 1f;

    [Tooltip("adjusts speed of movement in the air")][SerializeField] float jumpMoveSpeedDivider = 2f;
    [Tooltip("adjusts length golden mode exists")][SerializeField]  float goldenBeanLength = 5f;


    [Header("Layer Masks")]
    [SerializeField] LayerMask platformLayerMask;


    [SerializeField] UnityEvent onAttack;
    [SerializeField] UnityEvent onMove;



    private void Awake()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerBoxCollider = GetComponent<BoxCollider2D>();
        soundManager = FindObjectOfType<SoundManager>();
        playerAnimator = GetComponentInChildren<Animator>();

    }

   
    // getter for playerIsAttacking, used in Player_Booster to determine if the
    // player will be boosted by an enemy attack or not 
    public bool GetPlayerIsAttacking() { return playerIsAttacking; }
    public float GetMoveInputValue() { return moveInputXValue; }

    public bool BeanTouched
    {
        get => beanTouched;
        set => beanTouched = value;
    }

    public bool GoldenBeanTouched
    {
        get => goldenBeanTouched;
    }



    private void OnEnable()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
        _playerControls.GoldenPlayer.Disable();

        _playerControls.Player.Jump.performed += Jump;
        _playerControls.Player.Jump.canceled += JumpCut;
        _playerControls.Player.Fire.performed += Attack;
        _playerControls.Player.Fire.canceled += StopAttack;


    }

    private void Start()
    {
        if (onMove == null)
        {
            onMove = new UnityEvent();
        }

        if (onAttack == null)
        {
            onAttack = new UnityEvent();
        }
    }

    private void Update()
    {
        moveInputXValue = _playerControls.Player.Move.ReadValue<Vector2>().x;
        _rotateInputValue = _playerControls.GoldenPlayer.Rotate.ReadValue<Vector2>().x;

    }


    private void FixedUpdate()
    {
        Move();
        FlipPlayer();
        RotatePlayer();
        HandleFall();
    }


    private void OnDisable()
    {
        _playerControls.Disable();
    }


    /// <summary>
    /// Called in FixedUpdate, takes in the players movinput and applies force
    /// to player based on that input, allows for left and right movement.
    /// Movement is slowed by the JumpMoveSpeedDivider if player is in the air
    /// </summary>
    private void Move()
    {
        if (moveInputXValue != 0 && IsGrounded()) { playerAnimator.SetBool("isMoving", true); }
        else { playerAnimator.SetBool("isMoving", false); }

        float targetSpeed = moveInputXValue * moveSpeed;
        float speedDif = targetSpeed - _playerRigidBody.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deccelaration;

        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        
        Vector2 processedMoveVector = new Vector2(moveInputXValue, 0) * moveSpeed;
        if (!IsGrounded())
        {
            _playerRigidBody.AddForce(movement / jumpMoveSpeedDivider * Vector2.right * Time.deltaTime);
            //_playerRigidBody.AddForce((processedMoveVector / jumpMoveSpeedDivider) * Time.deltaTime, ForceMode2D.Impulse);
        }
        else
        {
            _playerRigidBody.AddForce(movement * Vector2.right * Time.deltaTime);
            // _playerRigidBody.AddForce(processedMoveVector * Time.deltaTime, ForceMode2D.Impulse);
            if (Mathf.Abs(moveInputXValue) < 0.01f)
            {
                float amount = Mathf.Min(Mathf.Abs(_playerRigidBody.velocity.x), Mathf.Abs(frictionAmount));
                amount *= Mathf.Sign(_playerRigidBody.velocity.x);
                _playerRigidBody.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
            }

        }

        onMove?.Invoke();

    }


    void FlipPlayer()
    {
        if (moveInputXValue < 0)
        {
             transform.localScale = new Vector2(-1f, 1f);

        }
        else if (moveInputXValue > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            return;
        }
        //bool playerHasHorizontalSpeed = Mathf.Abs(_playerRigidBody.velocity.x) > Mathf.Epsilon;
        //if (playerHasHorizontalSpeed)
        //{
        //    transform.localScale = new Vector2(Mathf.Sign(_playerRigidBody.velocity.x), 1f);
        //}
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

            _playerRigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            soundManager.Play("PlayerJump");
        }
    }


    private void JumpCut(InputAction.CallbackContext context)
    {
        if (_playerRigidBody.velocity.y > 0 && beanTouched == false)
        {

            _playerRigidBody.AddForce(Vector2.down * _playerRigidBody.velocity.y * (1 - jumpCutMultiplier), ForceMode2D.Impulse);
        }
    }


    /// <summary>
    /// Called during update, whenver the players velocity is less then 0 (IE
    /// player is falling), increase gravity on player for faster fall
    /// </summary>
    private void HandleFall()
    {
        if (_playerRigidBody.velocity.y < 0)
        {
            _playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }


    /// <summary>
    /// Called any time attack input action is performed. Generates hitbox while
    /// action is being performed and sets playerIsAttacking state to true
    /// </summary>
    /// <param name="context"></param>
    private void Attack(InputAction.CallbackContext context)
    {
        playerIsAttacking = true;
        playerAnimator.SetBool("isThrowing", true);
        onAttack?.Invoke();

    }


    /// <summary>
    /// Called when the attack input action is no longer being performed. Turns
    /// off hitbox and sets playerIsAttacking state to false
    /// </summary>
    /// <param name="obj"></param>
    private void StopAttack(InputAction.CallbackContext obj)
    {
        playerIsAttacking = false;
        playerAnimator.SetBool("isThrowing", false);


    }


    /// <summary>
    /// Called in Jump, utilizes raycast and layermasking to check if the player
    /// is touching a layer that they can jump on.
    /// (for now, "platforms")
    /// </summary>
    /// <returns>bool true or false</returns>
    public bool IsGrounded()
    {
        float extraHeightTest = .02f;
        RaycastHit2D raycastHit = Physics2D.Raycast(_playerBoxCollider.bounds.center, Vector2.down, _playerBoxCollider.bounds.extents.y + extraHeightTest, platformLayerMask);

        return raycastHit.collider != null;
    }

    /// <summary>
    /// switches control over to the golden movement for a few seconds when the player
    /// successfully reaches a golden bean 
    /// </summary>
    public void SwitchToGoldenMovement()
    {
        if (canMove)
        {
            goldenBeanTouched = true;
            startingConstraints = _playerRigidBody.constraints;
            canMove = !canMove;

            _playerRigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
            _playerControls.Player.Disable();
            _playerControls.GoldenPlayer.Enable();
            StartCoroutine(NormalMovementTimer());
        }
    }

    /// <summary>
    /// handles amount of time player stays in golden movement and resets
    /// player back to normal movement when time runs out 
    /// </summary>
    /// <returns></returns>
    public IEnumerator NormalMovementTimer()
    {
        
        yield return new WaitForSeconds(goldenBeanLength);
        canMove = !canMove;
        goldenBeanTouched = false;
        _playerControls.Player.Enable();
        _playerControls.GoldenPlayer.Disable();
        _playerRigidBody.velocity = transform.up * goldenHeight;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _playerRigidBody.constraints = startingConstraints;


    }

    /// <summary>
    /// handles rotation of the player during golden movement, rotation is only
    /// possible for the player while golden player movement is active 
    /// </summary>
    void RotatePlayer()
    {
        if (_playerControls.GoldenPlayer.enabled)
        {
            transform.rotation = Quaternion.Euler(0, 0, -_rotateInputValue * rotationSpeed);

        }
    }
}
