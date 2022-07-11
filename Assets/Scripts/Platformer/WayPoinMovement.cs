using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoinMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
   
    private SpriteRenderer _spriteRenderer;
    private float _speed = 1f;
    private int pointNumber = 0;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _points[pointNumber].position, _speed * Time.deltaTime);

        if (transform.position == _points[pointNumber].position)
        {
            if (pointNumber > 0)
            {
                pointNumber = 0;
                _spriteRenderer.flipX = false;
            }
            else
            {
                pointNumber = 1;
                _spriteRenderer.flipX = true;
            }
        }
    }
}
