using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigibody;
    private int _jumpPower = 300;

    public bool IsGrounded { get; private set; }
    public bool IsOnStairs { get; private set; }

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        IsOnStairs = false;
    }

    public void SetOnStairs()
    {
        IsOnStairs = true;
        _rigibody.gravityScale = 0;
        _rigibody.velocity = new Vector2(0, 0);
    }

    public void SetOffStairs()
    {
        IsOnStairs = false;
        _rigibody.gravityScale = 1;
    }

    public void SetGrounded()
    {
        IsGrounded = true;
    }

    public void RemoveGrounded()
    {
        IsGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            _rigibody.AddForce(new Vector2(0, _jumpPower));
        }

        if (Input.GetKey(KeyCode.W) && IsOnStairs)
        {
            transform.Translate(0, _speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S) && IsOnStairs)
        {
            transform.Translate(0, _speed * Time.deltaTime * -1, 0);
        }
    }
}
