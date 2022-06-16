using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController _controller;
    [SerializeField] float _speed = 11f;
    Vector2 _horizontalInput;

    public AudioSource _audio;
    public AudioClip _walkLoop;
    public AudioClip _jumpSound;

    [SerializeField] float _jumpHeight = 3.5f;
    bool _jump;
    bool _playJumpSound = false;

    [SerializeField] float _gravity = 30f;
    Vector3 _verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] bool _isGrounded;

    private void Update ()
    {
        _isGrounded = _controller.isGrounded;
        if (_isGrounded)
        {
            _verticalVelocity.y = 0;
            if (_playJumpSound)
            {
                _playJumpSound = false;
                _audio.volume = Random.Range(0.8f, 1);
                _audio.pitch = Random.Range(0.7f, 1.3f);
                _audio.PlayOneShot(_jumpSound);
            }
        }

        if (_verticalVelocity.y < 0)
        {
            _playJumpSound = true;
        }

        Vector3 _horizontalVelocity = (transform.right * _horizontalInput.x + transform.forward * _horizontalInput.y) * _speed;
        _controller.Move(_horizontalVelocity * Time.deltaTime);

        if (_jump)
        {
            if (_isGrounded)
            {
                _verticalVelocity.y = Mathf.Sqrt(-2f * _jumpHeight * -_gravity);
                _jump = false;
            }
        }

        _verticalVelocity.y -= _gravity * Time.deltaTime;
        _controller.Move(_verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput (Vector2 _horizontalInput)
    {
        this._horizontalInput = _horizontalInput;
    }

    public void OnJumpPressed ()
    {
        _jump = true;
    }
}
