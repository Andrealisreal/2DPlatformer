using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    public class MoneySpawner : MonoBehaviour
    {
        [SerializeField] private Money _prefab;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _delaySpawn = 2f;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            StartCoroutine(IntervalSpawning());
        }

        private IEnumerator IntervalSpawning()
        {
            var wait = new WaitForSeconds(_delaySpawn);

            yield return wait;

            var money = Instantiate(_prefab);
            money.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            money.Collected += Spawn;
        }
    }
}