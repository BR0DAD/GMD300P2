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

    //A LOT of variables
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

    //grabs player health and the character controller
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        currentPlayerHealth = playerHealth;
    }

    
    private void Update()
    {
        //makes it so over time the cooldown for the player to shoot a pinball goes down
        shotTime -= Time.deltaTime;

        //allows camera to move around
        Vector3 cameraSpaceMovement = new Vector3(moveInput.x, 0, moveInput.y);
        cameraSpaceMovement = Camera.main.transform.TransformDirection(cameraSpaceMovement);
        Vector2 cameraHorizontalMovement = new Vector2(cameraSpaceMovement.x, cameraSpaceMovement.z);

        currentHorizontalVelocity = Vector2.Lerp(currentHorizontalVelocity, cameraHorizontalMovement * moveMaxSpeed, Time.deltaTime * moveAcceleration);

        //code to check if the player is jumping
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

        //helps the player move
        if (horizontalDirection.magnitude > 0.0001)
        {

            Quaternion newDirection = Quaternion.LookRotation(horizontalDirection.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * moveAcceleration);
        }
       
        characterController.Move(currentVelocity * Time.deltaTime);
    }

    //moves the player
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    //makes player jump
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

    //this allows the player to shoot boulders also known as pinballs in this context
    public void OnAttack(InputValue value)
    {

        if (shotTime > 0)
        {
            return;
        }
        //cooldown to shoot boulder
        shotTime = shootDelay;

        //creates boulder
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

    //makes the player lose health
    public void LoseHealth(int health)
    {
        currentPlayerHealth -= health;

        //updates UI 
        TakeDamage();

        //game over
        if (currentPlayerHealth <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    //function to update the health UI
    public void TakeDamage()
    {
        healthBar.fillAmount =  currentPlayerHealth / playerHealth;
    }
}
