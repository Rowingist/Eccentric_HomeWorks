using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Coin _coinPrefab;

    public int SpawnedCoins { get; private set; }

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_coinPrefab, _spawnPoints[i]);
        }

        SpawnedCoins = _spawnPoints.Length;
    }
}