using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Skelet
{
    [RequireComponent(typeof(AudioSource))]

    public class Alarm : MonoBehaviour
    {
        [SerializeField] private UnityEvent _reached;
        private AudioSource _audioSource;
        private float _delta = 0.002f;
        private float _minTarget = 0f;
        private float _maxTarget = 1f;
        private Coroutine _coroutine;

        public void TurnOnAlarm()
        {
            _audioSource.Play();

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _coroutine = StartCoroutine(ChangeVolume(_maxTarget));
        }

        public void TurnOffAlarm()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ChangeVolume(_minTarget));
        }

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
                yield return null;
            }

            if (_audioSource.volume == _minTarget)
            {
                _audioSource.Stop();
            }
        }
    }

}
