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

    public void CheckLocation()
    {
        if (_playerMovement.IsGrounded)
        {
            _animator.SetBool(PlayerAnimationController.Params.Run, true);
        }
    }

   public void DisableAnimation()
    {
        _animator.SetBool(PlayerAnimationController.Params.Run, false);
    }

   public void FlipXOn()
    {
        _spriteRenderer.flipX = true;
    }

    public void FlipXOff()
    {
        _spriteRenderer.flipX = false;
    }

    private void Update()
    {
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
