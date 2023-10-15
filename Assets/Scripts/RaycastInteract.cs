using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastInteract : MonoBehaviour
{
    public Camera playerCamera;
    public float distance = 1;

    public InputActionAsset CharacterInputActions;
    public InputAction InteractAction;

    //finds action maps
    private void Awake()
    {
        CharacterInputActions.FindActionMap("Gameplay").Enable();

        InteractAction = CharacterInputActions.FindActionMap("Gameplay").FindAction("Interact");
    }

    private void OnDisable()
    {
        CharacterInputActions.FindActionMap("Gameplay").Disable();
    }
    // Update is called once per frame
    void Update()
    {
        Ray interactionRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit interactionHitInfo;

        bool interactInputPressed = InteractAction.triggered && InteractAction.ReadValue<float>() > 0;

        bool ShowInteractPrompt = false;

        if (Physics.Raycast(interactionRay, out interactionHitInfo, distance))
        {
            if (interactionHitInfo.transform.tag == "Interactible")
            {
                ShowInteractPrompt = true;
                if (interactInputPressed)
                {
                    interactionHitInfo.transform.SendMessage("OnPlayerInteract", SendMessageOptions.DontRequireReceiver);

                }
            }
            
        }

        UIAnimationManager.instance.ShowInteractPrompt(ShowInteractPrompt);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward);
    }
}
