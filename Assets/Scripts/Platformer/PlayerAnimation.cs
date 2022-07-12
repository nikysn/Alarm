using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerMovement))]

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void ÑheckLocation()
    {
        if (_playerMovement.IsGrounded)
        {
            _animator.SetBool(PlayerAnimationController.Params.Run, true);
        }
    }

    private void DisableAnimation()
    {
        _animator.SetBool(PlayerAnimationController.Params.Run, false);
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;

            ÑheckLocation();
        }
        if (Input.GetKeyUp(KeyCode.A) || _playerMovement.IsGrounded == false)
        {
            DisableAnimation();
        }

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;

            ÑheckLocation();
        }
        if (Input.GetKeyUp(KeyCode.D) || _playerMovement.IsGrounded == false)
        {
            DisableAnimation();
        }

        if (_playerMovement.IsGrounded == false && _playerMovement.IsOnStairs == false)
        {
            _animator.SetBool(PlayerAnimationController.Params.Jump, true);
        }
        else
        {
            _animator.SetBool(PlayerAnimationController.Params.Jump, false);
        }
    }
}
