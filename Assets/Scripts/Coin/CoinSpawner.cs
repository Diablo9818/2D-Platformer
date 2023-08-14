using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Coin _coinPrefab;
    [SerializeField] private List<Vector3> _spawnPositions;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _spawnPositions.Count; i++)
        {
            Vector3 spawnPosition = _spawnPositions[i];
            Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
