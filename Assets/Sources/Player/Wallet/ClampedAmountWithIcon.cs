using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClampedAmountWithIcon : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;

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
        if(_icon == null)
        {
            throw new InvalidOperationException();
        }    

        if(_text == null)
        {
            throw new InvalidOperationException();  
        }
    }

    public void SetAmount(int amount, int maxAmount)
    {
        _text.text = $"{amount}";
        _icon.color = Color.Lerp(Color.white, Color.yellow, amount / maxAmount);
    }

    private void OnCollect()
    {
        CoinCollected?.Invoke();
    }
}