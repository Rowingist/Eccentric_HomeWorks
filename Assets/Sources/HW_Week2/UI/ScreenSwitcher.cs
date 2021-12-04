using System.Collections;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private float _delay = 3f;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _gameLogic.GameOver += OnActivate;
    }

    private void OnDisable()
    {
        _gameLogic.GameOver -= OnActivate;
    }

    private void OnActivate()
    {
        StartCoroutine(DelayGameStop(_delay));
    }

    private IEnumerator DelayGameStop(float delay)
    {
        _gameOverScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0;
    }
}