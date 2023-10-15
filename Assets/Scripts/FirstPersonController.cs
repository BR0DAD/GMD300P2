using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    public float MoveSpeed;
    public float RotationSpeed;
    private float verticalMovement = 0;

    public InputActionAsset CharacterActionAsset;

    public Camera FirstPersonCamera;

    private InputAction moveAction;
    private InputAction rotateAction;

    private CharacterController characterController;

    //Vector Variables for frame inputs
    private Vector2 inputMovement = Vector2.zero;
    private Vector2 previousFrameInputMovement = Vector2.zero;
    private Vector2 inputRotation = Vector2.zero;
    private Vector2 previousFrameInputRotation = Vector2.zero;

    private Vector2 moveValue = Vector2.zero;
    private Vector2 rotateValue = Vector2.zero;
    private Vector3 currentRotationAngle = Vector3.zero;

    //Jump
    public float MaxJumpHeight = 1;
    public LayerMask GroundLayer;
    public float GroundCheckRadius = 0.25f;
    public Transform GroundCheck;

    private InputAction jumpAction;
    private bool isJumping = false;
    private bool isGrounded = false;

    //finds inputs
    private void OnEnable()
    {
        CharacterActionAsset.FindActionMap("Gameplay").Enable();
    }
    private void OnDisable()
    {
        CharacterActionAsset.FindActionMap("Gameplay").Disable();
    }
    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        moveAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Move");
        rotateAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Rotate");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        jumpAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
      
        rotateValue = rotateAction.ReadValue<Vector2>() * Time.deltaTime * RotationSpeed;

        currentRotationAngle = new Vector3(currentRotationAngle.x - rotateValue.y, currentRotationAngle.y + rotateValue.x, 0);

        currentRotationAngle = new Vector3(Mathf.Clamp(currentRotationAngle.x, -85, 85), currentRotationAngle.y, currentRotationAngle.z);

        FirstPersonCamera.transform.rotation = Quaternion.Euler(currentRotationAngle);
        

        LookMovement();
        ProcessJump();
    }

    //helps with look sensitivity
   private void LookMovement() 
    {
        moveValue = moveAction.ReadValue<Vector2>() * MoveSpeed;
        Vector3 MoveDirection = FirstPersonCamera.transform.forward * moveValue.y + FirstPersonCamera.transform.right * moveValue.x;
        MoveDirection.y = 0;
        MoveDirection.y += verticalMovement;
        characterController.Move(MoveDirection*Time.deltaTime);

    }

    //debug on player
    void OnDrawGizmos ()
    {
        Gizmos.color = new Vector4(0, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }

    //processes the jump input and makes player jump
    private void ProcessJump()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, GroundLayer);


        if (characterController.isGrounded && verticalMovement < 0)
        {
            isJumping = false;
            verticalMovement = 0;
        }
        if (isGrounded && !isJumping)
        {
            bool JumpButtonDown = jumpAction.triggered && jumpAction.ReadValue<float>() > 0;
            if (JumpButtonDown)
            {
                float Jumpforce = Mathf.Sqrt(-2 * MaxJumpHeight * Physics.gravity.y);
                verticalMovement += Jumpforce;
                isJumping = true;
            }
        }
        verticalMovement += Physics.gravity.y * Time.deltaTime;
        characterController.Move(Vector3.up*verticalMovement*Time.deltaTime);
    }
}
