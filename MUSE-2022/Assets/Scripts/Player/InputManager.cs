using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Movement _movement;
    [SerializeField] MouseLook _mouseLook;

    PlayerControls _playerControls;
    PlayerControls.MovementActions _playerMovement;

    Vector2 _horizontalInput;
    Vector2 _mouseInput;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerMovement = _playerControls.Movement;

        _playerMovement.Move.performed += context => _horizontalInput = context.ReadValue<Vector2>();

        _playerMovement.Jump.performed += _ => _movement.OnJumpPressed();

        _playerMovement.CameraX.performed += context => _mouseInput.x = context.ReadValue<float>();
        _playerMovement.CameraY.performed += context => _mouseInput.y = context.ReadValue<float>();
    }

    private void Update()
    {
        _movement.ReceiveInput(_horizontalInput);
        _mouseLook.ReceiveInput(_mouseInput);
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
