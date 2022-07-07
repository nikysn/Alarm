using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skelet;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Spider _spider;

        private Transform[] _spawnPoints;

        public Transform Target { get { return _target; } }

        private void Start()
        {
            _spawnPoints = new Transform[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                _spawnPoints[i] = transform.GetChild(i);
            }

            StartCoroutine(CreateSpiders());
        }

        private IEnumerator CreateSpiders()
        {
            while (true)
            {
                for(int i = 0; i < _spawnPoints.Length; i++)
                {
                    Spider spider = Instantiate(_spider, _spawnPoints[i].position, Quaternion.identity);
                    spider.SetTarget(_target);
                    yield return new WaitForSeconds(2f);
                }
            }
        }
    }
}
