using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 80f;

    private void Update()
    {
        transform.Rotate(0f, 0f ,_rotationSpeed * Time.deltaTime);
    }
}
