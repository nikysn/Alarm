using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

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

    public void AnimationJumpOn()
    {
          _animator.SetBool(PlayerAnimationController.Params.Jump, true);

    }

    public void AnimationJumpOff()
    {
        _animator.SetBool(PlayerAnimationController.Params.Jump, false);
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;

            if (_playerMovement.IsGrounded)
            {
                _animator.SetBool(PlayerAnimationController.Params.Run, true);
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || _playerMovement.IsGrounded == false)
        {
            _animator.SetBool(PlayerAnimationController.Params.Run, false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;

            if (_playerMovement.IsGrounded)
            {
                _animator.SetBool(PlayerAnimationController.Params.Run, true);

            }
        }
        if (Input.GetKeyUp(KeyCode.D) || _playerMovement.IsGrounded == false)
        {
            _animator.SetBool(PlayerAnimationController.Params.Run, false);
        }

        if (_playerMovement.IsGrounded == false && _playerMovement.IsOnStairs == false)
        {
            AnimationJumpOn();
        }
        else
        {
            AnimationJumpOff();
        }

    }

}
