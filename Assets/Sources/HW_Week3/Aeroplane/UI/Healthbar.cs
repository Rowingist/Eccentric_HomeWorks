using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Healthbar : MonoBehaviour
{
    [SerializeField] private AeroplanePlayer _player;

    private Slider _healthBar;

    private void Awake()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _player.Health / 100;
        _healthBar.value = _healthBar.maxValue;
    }

    private void OnEnable()
    {
        _player.Hurt += OnChangeValue;
    }

    private void OnDisable()
    {
        _player.Hurt -= OnChangeValue;
    }

    private void OnChangeValue()
    {
        if (_healthBar.value <= 0f)
        {
            return;
        }

        StartCoroutine(SmoothMoveHealthFill(_player.Health / 100f));
    }

    private IEnumerator SmoothMoveHealthFill(float playerCurrentHealth)
    {
        float time = 0f;

        const float ANIMARION_DURATION = 1f;

        while (time < 1f)
        {
            _healthBar.value = Mathf.Lerp(_healthBar.value, playerCurrentHealth, time);
            time += Time.deltaTime / ANIMARION_DURATION;

            yield return null;
        }
    }
}