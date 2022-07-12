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

    public void MoveLeft()
    {
        transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
    }

    public void MoveRight()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    public void Jump()
    {
        _rigibody.AddForce(new Vector2(0, _jumpPower));
    }

    public void MoveUp()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);
    }

    public void MoveDown()
    {
        transform.Translate(0, _speed * Time.deltaTime * -1, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
    }

   
}
