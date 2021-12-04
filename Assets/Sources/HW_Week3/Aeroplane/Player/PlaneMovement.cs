using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlaneMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _speed = 5f;
    [SerializeField, Range(0f, 10f)] private float _rotationSpeed = 3f;
    [SerializeField] private AeroplaneGameLogic _gameLogic;
    [SerializeField] private AudioSource _audioSource;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _gameLogic.GameWon += OnSwitchAutoPilot;
    }

    private void OnDisable()
    {
        _gameLogic.GameWon -= OnSwitchAutoPilot;
    }

    private void Update()
    {
        _audioSource.pitch = Input.GetAxis("Vertical") + 1f;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 playerInput = transform.forward * Input.GetAxis("Vertical");
        playerInput = Vector3.ClampMagnitude(playerInput, 1f);
        Vector3 speedVector = playerInput * _speed;
        _rigidbody.AddForce(speedVector, ForceMode.Acceleration);

    }

    private void Rotate()
    {
        float sideForce = Input.GetAxis("Horizontal") * _rotationSpeed;
        _rigidbody.AddRelativeTorque(sideForce, 0f, 0f);
    }

    private void OnSwitchAutoPilot()
    {
        enabled = false;
        _rigidbody.useGravity = false;
        StartCoroutine(DelayStoping());
    }

    private IEnumerator DelayStoping()
    {
        yield return new WaitUntil(() => _rigidbody.velocity == Vector3.zero);
        _rigidbody.isKinematic = true;
    }
}