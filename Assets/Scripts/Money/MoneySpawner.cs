using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Money _prefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Spawn()
    {
        var money = Instantiate(_prefab);
        money.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
    }
}
