using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skelet
{
    public class PlayerMovement : MonoBehaviour
    {


        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody.MovePosition(transform.position + Vector3.left * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {
                _rigidbody.MovePosition(transform.position + Vector3.up * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody.MovePosition(transform.position + Vector3.right * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _rigidbody.MovePosition(transform.position + Vector3.down * _speed * Time.deltaTime);
            }
        }

    }
}
