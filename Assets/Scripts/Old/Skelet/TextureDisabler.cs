using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skelet
{
    public class TextureDisabler : MonoBehaviour
    {
        [SerializeField] private House _house;
        [SerializeField] private Roof _roof;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                _roof.gameObject.SetActive(false);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                _roof.gameObject.SetActive(true);
            }
        }
    }
}
