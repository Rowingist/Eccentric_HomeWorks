using System;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _winWindow;
    [SerializeField] private CanvasGroup _lostWindow;
    [SerializeField] private AeroplaneGameLogic _gameLogic;
    [SerializeField] private AeroplanePlayer _player;

    public event Action GameEnded;

    private void OnEnable()
    {
        try
        {
            Validate();
        }
        catch(Exception e)
        {
            enabled = false;
            throw e;
        }

        _gameLogic.GameWon += OnWin;
        _player.Died += OnLost;
    }

    private void OnDisable()
    {
        _gameLogic.GameWon -= OnWin;
        _player.Died -= OnLost;
    }

    private void Validate()
    {
        if (_winWindow == null)
        {
            throw new InvalidOperationException();
        }

        if (_lostWindow == null)
        {
            throw new InvalidOperationException();
        }
    }

    private void OnWin()
    {
        EnableWindow(_winWindow);
        GameEnded?.Invoke();
    }

    private void OnLost()
    {
        EnableWindow(_lostWindow);
        GameEnded?.Invoke();
    }

    public void EnableWindow(CanvasGroup window)
    {
        window.alpha = 1;
    }
}