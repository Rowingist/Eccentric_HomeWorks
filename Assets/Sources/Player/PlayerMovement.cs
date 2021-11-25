using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _speed = 10f;
    [SerializeField, Range(0f, 100f)] private float _speedBooster = 3f;
    [SerializeField, Range(0f, 360f)] private float _rotationSpeed = 200f;
    [SerializeField, Range(0f, 100f)] private float _maxAcceleration = 10f;

    private Vector3 _velocity, _rotation;
    private Vector3 _playerInputX, _playerInputZ;
    private Rigidbody _rigidbody;

    private float _inputRotation, _currentSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentSpeed = _speed;
    }

    private void Update()
    {
        _playerInputX = transform.right * Input.GetAxis("Horizontal");
        _playerInputZ = transform.forward * Input.GetAxis("Vertical");
        _inputRotation = Input.GetAxis("Mouse X");

        _currentSpeed = Input.GetKey(KeyCode.LeftShift) ? _speed * _speedBooster : _speed;
    }

    private void FixedUpdate()
    {
        _velocity = _rigidbody.velocity;
        float maxSpeedChange = _maxAcceleration * Time.deltaTime;
        _velocity = (_playerInputX + _playerInputZ) * _currentSpeed * maxSpeedChange;
        _rotation = new Vector3(0f, _inputRotation, 0f);
        Quaternion deltaRotation = Quaternion.Euler(_rotation * Time.deltaTime * _rotationSpeed);

        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        _rigidbody.velocity = _velocity;
    }
}