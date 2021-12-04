using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AirCoin : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 80f;

    private AudioSource _collectSound;

    private void Start()
    {
        _collectSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
    }

    public void Destroy()
    {
        StartCoroutine(DelayDestroy());
    }

    private IEnumerator DelayDestroy()
    {
        _collectSound.Play();
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}