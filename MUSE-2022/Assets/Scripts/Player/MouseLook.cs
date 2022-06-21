using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float _sensitivityX = 45f;
    [SerializeField] float _sensitivityY = 0.1f;

    float _mouseX, _mouseY;

    [SerializeField] Transform _playerCamera;
    [SerializeField] float _cameraMax = 85f;
    float _xRotation = 0f;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, _mouseX * Time.deltaTime);

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, - _cameraMax, _cameraMax);

        Vector3 _currentRotation = transform.eulerAngles;
        _currentRotation.x = _xRotation;
        _playerCamera.eulerAngles = _currentRotation;
    }

    public void ReceiveInput (Vector2 _mouseInput)
    {
        _mouseX = _mouseInput.x * _sensitivityX;
        _mouseY = _mouseInput.y * _sensitivityY;
    }
}
