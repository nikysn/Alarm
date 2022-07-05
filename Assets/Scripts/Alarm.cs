using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    private AudioSource _audioSource;
    private float _delta = 0.002f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (_audioSource.volume != volume)
        {
            Debug.Log("ћен€ю звук");
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _delta);

            if (_audioSource.volume == _minVolume)
            {
                _audioSource.Stop();
            }

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_audioSource.isPlaying == false)
            {
                _reached?.Invoke();
                Debug.Log("¬ключаю звук");
            }
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _coroutine = StartCoroutine(ChangeVolume(_maxVolume));

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ChangeVolume(_minVolume));
        }
    }
}
