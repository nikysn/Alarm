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
        
        private const string RunRight = "RunRight";
        private const string RunLeft = "RunLeft";
        private const string RunUp = "RunUp";
        private const string RunDown = "RunDown";
       
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
                _animator.SetBool(RunRight, true);

                _spriteRenderer.flipX = false;

            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                _animator.SetBool(RunRight, false);
            }


            if (Input.GetKeyDown(KeyCode.A))
            {
                _animator.SetBool(RunLeft, true);

                _spriteRenderer.flipX = false;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                _animator.SetBool(RunLeft, false);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _animator.SetBool(RunUp, true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                _animator.SetBool(RunUp, false);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _animator.SetBool(RunDown, true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                _animator.SetBool(RunDown, false);
            }
        }
    }
}
