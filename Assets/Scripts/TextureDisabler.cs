using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureDisabler : MonoBehaviour
{
    [SerializeField] private House _house;
    [SerializeField] private Roof _roof;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _house.gameObject.SetActive(false);
            _roof.gameObject.SetActive(false);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _house.gameObject.SetActive(true);
            _roof.gameObject.SetActive(true);
        }
    }
}
