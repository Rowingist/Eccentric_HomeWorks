using System;
using System.Collections;
using UnityEngine;

public class AeroplanePlayer : MonoBehaviour
{
    [SerializeField] private float _health = 5f;
    [SerializeField] private GameObject _aeroplaneView;
    [SerializeField] private GameObject _engineSound;

    public event Action Collected;
    public event Action Died;
    public event Action Hurt;

    public float Health => _health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AirCoin coin))
        {
            Collected?.Invoke();
            coin.Destroy();
        }
    }

    public void TryDie(float damage)
    {
        _health--;
        Hurt?.Invoke();

        if (_health <= 0)
        {
            StartCoroutine(DelayDestroy(1f));
        }
    }

    private IEnumerator DelayDestroy(float delay)
    {
        _aeroplaneView.SetActive(false);
        GetComponent<PlaneMovement>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        _engineSound.SetActive(false);
        GetComponentInChildren<ParticleSystem>().Play();
        GetComponentInChildren<AudioSource>().Play();
        Died?.Invoke();
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}