using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AeroplaneGameLogic : MonoBehaviour
{
    [SerializeField] private int _coinsToWin = 10;
    [SerializeField] private ClampedAmountWithIconPlane _waletModelView;
    [SerializeField] private PlaneWalletSetup _walletSetup;
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private EndWindow _endWindow;
    [SerializeField] private ParticleSystem _confetty;

    public event Action GameWon;

    public int CoinsToWin => _coinsToWin;

    private void OnEnable()
    {
        _startWindow.PlayButtonClicked += OnPlayButtonClick;
        _endWindow.RestartButtonClicked += OnRestartButtonClicked;
        _waletModelView.CoinCollected += OnEndGame;
    }

    private void OnDisable()
    {
        _startWindow.PlayButtonClicked -= OnPlayButtonClick;
        _endWindow.RestartButtonClicked -= OnRestartButtonClicked;
        _waletModelView.CoinCollected -= OnEndGame;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startWindow.Open();
    }

    private void OnPlayButtonClick()
    {
        _startWindow.Close();
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        _endWindow.Close();
        SceneManager.LoadScene(0);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void OnEndGame()
    {
        if (_walletSetup.Coins < _coinsToWin)
        {
            return;
        }

        GameWon?.Invoke();
        _confetty.gameObject.GetComponent<AudioSource>().Play();
        _confetty.Play();
    }
}