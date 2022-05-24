using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;

    PlayerControls playerControls;
    PlayerControls.MovementActions playerMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerMovement = playerControls.Movement;

        playerMovement.Move.performed += context => horizontalInput = context.ReadValue<Vector2>();

        playerMovement.Jump.performed += _ => movement.OnJumpPressed();

        playerMovement.CameraX.performed += context => mouseInput.x = context.ReadValue<float>();
        playerMovement.CameraY.performed += context => mouseInput.y = context.ReadValue<float>();
    }

    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
