using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
	[SerializeField] private Transform _focus = default;
	[SerializeField, Range(1f, 50f)] private float _distance = 5f;
	[SerializeField, Min(0f)] private float _focusRadius = 5f;
	[SerializeField, Range(0f, 1f)] private float _focusCentering = 0.5f;

	private Vector3 _focusPoint;

	void Awake()
	{
		_focusPoint = _focus.position;
		transform.localRotation = Quaternion.identity;
	}

	void LateUpdate()
	{
		UpdateFocusPoint();
		Quaternion lookRotation = transform.localRotation;
		Vector3 lookDirection = lookRotation * Vector3.forward;
		Vector3 lookPosition = _focusPoint - lookDirection * _distance;
		transform.SetPositionAndRotation(lookPosition, transform.localRotation);
	}

	void UpdateFocusPoint()
	{
		Vector3 targetPoint = _focus.position;
		if (_focusRadius > 0f)
		{
			float distance = Vector3.Distance(targetPoint, _focusPoint);
			float t = 1f;
			if (distance > 0.01f && _focusCentering > 0f)
			{
				t = Mathf.Pow(1f - _focusCentering, Time.unscaledDeltaTime);
			}
			if (distance > _focusRadius)
			{
				t = Mathf.Min(t, _focusRadius / distance);
			}
			_focusPoint = Vector3.Lerp(targetPoint, _focusPoint, t);
		}
		else
		{
			_focusPoint = targetPoint;
		}
	}
}