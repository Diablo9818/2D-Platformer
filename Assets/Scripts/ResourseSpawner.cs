using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseSpawner : MonoBehaviour
{
    [SerializeField] Coin _coinPrefab;
    [SerializeField] HealthBooster _healthBooster;
    [SerializeField] private List<Vector3> _spawnCoinsPositions;
    [SerializeField] private List<Vector3> _spawnBoostersPositions;

    private void Start()
    {
        SpawnCoins();
        SpawnHealthBoosters();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _spawnCoinsPositions.Count; i++)
        {
            Vector3 spawnPosition = _spawnCoinsPositions[i];
            Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void SpawnHealthBoosters()
    {
        for (int i = 0; i < _spawnBoostersPositions.Count; i++)
        {
            Vector3 spawnPosition = _spawnBoostersPositions[i];
            Instantiate(_healthBooster, spawnPosition, Quaternion.identity);
        }
    }
}
