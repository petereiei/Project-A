using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    protected Rigidbody rigidBody;
    protected Character character;
    protected PlayerInput playerInput;
    public CharacterController characterController;

    private GameControls controls = null;
    private Vector3 direction;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    private Vector3 velocity;
    private float speed = 1f;
    private float gravity = -9.81f;
    private float jumpHeight = 1f;

    private void Awake()
    {
        controls = new GameControls();

        rigidBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
    }

    public void Init(Character character)
    {
        this.character = character;

        controls.Player.Jump.performed += context => OnJump(context);
        controls.Player.Movement.performed += context => OnMave(context);
        controls.Player.Movement.canceled += context => OnMave(context);
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Update()
    {
        Movement(direction);
        OnFall();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (!isGrounded)
            return;

        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        character.onJump?.Invoke(true);
    }

    private bool jump;

    private void OnFall()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            jump = true;
        }
        if (jump && !isGrounded)
        {
            jump = false;
            character.characterAnimator.Jump(jump);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnMave(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    private void Movement(Vector3 direction)
    {
        direction = new Vector3
        {
            x = direction.x,
            z = direction.y
        }.normalized;

        characterController.Move(direction * MoveDistancePerFrame());

        character.onMove?.Invoke(new Vector2() { x = direction.x, y = direction.z});
    }

    private float MoveDistancePerFrame()
    {
        return speed * Time.fixedDeltaTime;
    }
}
