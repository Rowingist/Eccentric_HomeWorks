using System;
using UnityEngine;
using TMPro;

public class ClampedAmountWithIconPlane : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AeroplanePlayer _player;

    public event Action CoinCollected;

    private void OnEnable()
    {
        try
        {
            Validate();
        }
        catch (Exception e)
        {
            enabled = false;
            throw e;
        }
        _player.Collected += OnCollect;
    }

    private void OnDisable()
    {
        _player.Collected -= OnCollect;
    }

    private void Validate()
    { 
        if(_text == null)
        {
            throw new InvalidOperationException();  
        }
    }

    public void SetAmount(int amount)
    {
        _text.text = $"{amount}";
    }

    private void OnCollect()
    {
        CoinCollected?.Invoke();
    }
}