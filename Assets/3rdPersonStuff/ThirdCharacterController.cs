using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class ThirdCharacterController : MonoBehaviour
{

    public Camera Camera;
    public GameObject BOULDER_Prefab;
    public Transform projectileReference;
    
    public int playerHealth = 3;

    public float moveMaxSpeed = 5;
    public float moveAcceleration = 10;

    public float jumpSpeed = 5;
    public float jumpMaxTime = 0.5f;
    private float jumpTimer = 0;

    private CharacterController characterController;

    private Vector2 moveInput = Vector2.zero;
    private Vector2 currentHorizontalVelocity = Vector2.zero;
    private float currentVerticalVelocity = 0;

    private bool jumpInputPressed = false;
    private bool isJumping = false;
    public float shootDelay;
    private float shotTime;

    public Image healthBar;
    public float healthAmount = 100f;
    private float currentPlayerHealth;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        currentPlayerHealth = playerHealth;
    }

    private void Update()
    {
        shotTime -= Time.deltaTime;
        Vector3 cameraSpaceMovement = new Vector3(moveInput.x, 0, moveInput.y);
        cameraSpaceMovement = Camera.main.transform.TransformDirection(cameraSpaceMovement);
      

        Vector2 cameraHorizontalMovement = new Vector2(cameraSpaceMovement.x, cameraSpaceMovement.z);

        currentHorizontalVelocity = Vector2.Lerp(currentHorizontalVelocity, cameraHorizontalMovement * moveMaxSpeed, Time.deltaTime * moveAcceleration);

        if(isJumping == false) 
        {
            currentVerticalVelocity += Physics.gravity.y * Time.deltaTime;
            
            if(characterController.isGrounded && currentVerticalVelocity < 0)
            {
                currentVerticalVelocity = Physics.gravity.y * Time.deltaTime;
            }
        }
        else
        {
            jumpTimer += Time.deltaTime;

            if(jumpTimer >= jumpMaxTime)
            {
                isJumping = false;
            }
        }

        Vector3 currentVelocity = new Vector3(currentHorizontalVelocity.x, currentVerticalVelocity, currentHorizontalVelocity.y);

        Vector3 horizontalDirection = Vector3.Scale(currentVelocity, new Vector3(1, 0, 1));

        if (horizontalDirection.magnitude > 0.0001)
        {

            Quaternion newDirection = Quaternion.LookRotation(horizontalDirection.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * moveAcceleration);
        }
       
        characterController.Move(currentVelocity * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        jumpInputPressed = value.Get<float>() > 0;

        if (jumpInputPressed)
        {
            if (characterController.isGrounded)
            {
                isJumping = true;

                jumpTimer = 0;

                currentVerticalVelocity = jumpSpeed;
            }
        }
        else
        {
            if (isJumping)
            {
                isJumping = false;
            }
        }
    }

    public void OnAttack(InputValue value)
    {

        if (shotTime > 0)
        {
            return;
        }
        shotTime = shootDelay;
        Instantiate(BOULDER_Prefab, projectileReference.position, Quaternion.identity);
        Collider[] overlapItems = Physics.OverlapBox(transform.position, Vector3.one);

        if (overlapItems.Length > 0)
        {
            foreach(Collider item in overlapItems)
            {
                Vector3 direction = item.transform.position - transform.position;
                item.SendMessage("SHOOT", direction, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    public void LoseHealth(int health)
    {
        currentPlayerHealth -= health;
        TakeDamage();
        if (currentPlayerHealth <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void TakeDamage()
    {
        healthBar.fillAmount =  currentPlayerHealth / playerHealth;
    }
}
