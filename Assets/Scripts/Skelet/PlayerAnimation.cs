using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Skelet
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]

    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private bool _isFliped = false;
        private const string _runRight = "RunRight";
        private const string _runLeft = "RunLeft";
        private const string _runUp = "RunUp";
        private const string _runDown = "RunDown";
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                _spriteRenderer.flipX = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                _animator.SetBool(_runRight, true);

                _spriteRenderer.flipX = false;

            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                _animator.SetBool(_runRight, false);
            }


            if (Input.GetKeyDown(KeyCode.A))
            {
                _animator.SetBool(_runLeft, true);

                _spriteRenderer.flipX = false;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                _animator.SetBool(_runLeft, false);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _animator.SetBool(_runUp, true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                _animator.SetBool(_runUp, false);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _animator.SetBool(_runDown, true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                _animator.SetBool(_runDown, false);
            }
        }
    }
}
