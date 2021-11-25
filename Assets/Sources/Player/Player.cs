using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action Collected;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            Collected?.Invoke();
            Destroy(coin.gameObject);
        }
    }
}