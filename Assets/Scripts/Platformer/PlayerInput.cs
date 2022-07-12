using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _playerMovement.MoveLeft();
            _playerAnimation.FlipXOn();
            _playerAnimation.CheckLocation();
        }
        if (Input.GetKeyUp(KeyCode.A) || _playerMovement.IsGrounded == false)
        {
            _playerAnimation.DisableAnimation();
        }

        if (Input.GetKey(KeyCode.D))
        {
            _playerMovement.MoveRight();
            _playerAnimation.FlipXOff();
            _playerAnimation.CheckLocation();
        }
        if (Input.GetKeyUp(KeyCode.D) || _playerMovement.IsGrounded == false)
        {
            _playerAnimation.DisableAnimation();
        }

        if (Input.GetKeyDown(KeyCode.Space) && _playerMovement.IsGrounded)
        {
            _playerMovement.Jump();
        }

        if (Input.GetKey(KeyCode.W) && _playerMovement.IsOnStairs)
        {
            _playerMovement.MoveUp();
        }
        if (Input.GetKey(KeyCode.S) && _playerMovement.IsOnStairs)
        {
            _playerMovement.MoveDown();
        }
    }
}
