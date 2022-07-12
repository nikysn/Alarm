using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skelet
{
    public class House : MonoBehaviour
    {
        [SerializeField] private Alarm _alarm;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {

                _alarm.TurnOnAlarm();
                Debug.Log("¬ключаю звук");


            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                _alarm.TurnOffAlarm();
            }
        }
    }
}
