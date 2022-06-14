using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    Vector2 horizontalInput;

    public AudioSource audio;
    public AudioClip walkLoop;
    public AudioClip jumpSound;

    [SerializeField] float jumpHeight = 3.5f;
    bool jump;
    bool playJumpSound = false;

    [SerializeField] float gravity = 30f;
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    [SerializeField] bool isGrounded;

    private void Update ()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            verticalVelocity.y = 0;
            if (playJumpSound)
            {
                playJumpSound = false;
                audio.volume = Random.Range(0.8f, 1);
                audio.pitch = Random.Range(0.7f, 1.3f);
                audio.PlayOneShot(jumpSound);
            }
        }

        if (verticalVelocity.y < 0)
        {
            playJumpSound = true;
        }

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (jump)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * -gravity);
                jump = false;
            }
        }

        verticalVelocity.y -= gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput (Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    public void OnJumpPressed ()
    {
        jump = true;
    }
}
