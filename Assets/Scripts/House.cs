using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {

            _alarm.TurnOnAlarm();
            Debug.Log("Включаю звук");


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
/*1. float volume - лучше подойдет название target 
 * 2. if (_audioSource.volume == _minVolume) { _audioSource.Stop(); } - это рациональнее проверить в конце корутины 
 * 3. Разделите ответственности. Сигнализация должна только менять громкость, контроль входа это задача для другой сущности 
 * 4. _animator.SetBool("RunRight", true); - не используйте строковые литералы при работе с PlayerPrefs, аниматором или кнопками напрямую. 
 * Подробное описание: https://agava.notion.site/40e2798c8c32487583180b03cbc5fccd 
 * 5. public class PlayerMove -> PlayerMovement 
 * 6. В классе PlayerMove дублируется код движения, нужно выделить часть которая дублируется*/