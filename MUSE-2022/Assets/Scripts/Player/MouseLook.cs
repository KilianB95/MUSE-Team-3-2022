using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivityX = 45f;
    [SerializeField] float sensitivityY = 0.1f;

    float mouseX, mouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float cameraMax = 85f;
    float xRotation = 0f;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, - cameraMax, cameraMax);

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.x = xRotation;
        playerCamera.eulerAngles = currentRotation;
    }

    public void ReceiveInput (Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }
}
