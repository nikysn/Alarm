using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodStairs : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            playerMovement.SetOnStairs();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            playerMovement.SetOffStairs();
        }
    }
}
