using System;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private ClampedAmountWithIcon _waletModelView;
    [SerializeField] private WalletSetup _walletSetup;

    public event Action GameOver;

    private void OnEnable()
    {
        _waletModelView.CoinCollected += OnEndGame;
    }

    private void OnDisable()
    {
        _waletModelView.CoinCollected -= OnEndGame;
    }

    private void OnEndGame()
    {
        if(_walletSetup.Coins < _coinSpawner.SpawnedCoins)
        {
            return;
        }

        GameOver?.Invoke();
    }
}