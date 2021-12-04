using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bomb : MonoBehaviour
{
    private float _damge = 1f;

    private AudioSource _explosionSound;

    private void Start()
    {
        _explosionSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out AeroplanePlayer plane))
        {
            plane.TryDie(_damge);
        }

        Destroy();
    }

    private void Destroy()
    {
        StartCoroutine(DelayDestroy());
    }

    private IEnumerator DelayDestroy()
    {
        _explosionSound.Play();
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}