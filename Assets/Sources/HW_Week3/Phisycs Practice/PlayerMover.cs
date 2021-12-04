using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _rotationSensitivity;
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _jumpForce = 4f;

    private Camera _mainCamera;
    private Rigidbody _rigidbody;

    private float _xRotation, _yRotation;
    private bool _grounded;

    private void Start()
    {
        _mainCamera = GetComponentInChildren<Camera>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _xRotation -= Input.GetAxis("Mouse Y") * _rotationSensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -60f, 60f);
            _mainCamera.transform.localEulerAngles = new Vector3(_xRotation, 0f, 0f);

            _yRotation = Input.GetAxis("Mouse X") * _rotationSensitivity;
            transform.Rotate(new Vector3(0f, _yRotation, 0f));
        }

        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _rigidbody.AddForce(0f, _jumpForce, 0f, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 speedVector = inputVector * _moveSpeed;

        Vector3 speedRelativeToPlayer = transform.TransformVector(speedVector);

        _rigidbody.velocity = new Vector3(speedRelativeToPlayer.x, _rigidbody.velocity.y, speedRelativeToPlayer.z);
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot > 0.5f)
        {
            _grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }
}