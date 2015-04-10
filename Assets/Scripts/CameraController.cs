using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public Transform targetTransform;
	[SerializeField, Range(1, 10)] public float cameraDistance = 2f;
	public Vector3 offset = Vector3.up;

	float previousPinchDistance = 0.1f;

	enum TouchPhase {
		Untouched,
		Began,
		Pinched
	}
	TouchPhase touchPhase = TouchPhase.Untouched;

	void Start ()
	{
		if (targetTransform == null)
			targetTransform = GameObject.Find ("Alicia").transform;

		if (targetTransform == null)
			targetTransform.position = Vector3.zero;
	}
	// Update is called once per frame
	void Update ()
	{
		switch (touchPhase) {
		case TouchPhase.Untouched:
			if (Input.touchCount >= 2)
				touchPhase = TouchPhase.Began;
			break;
		case TouchPhase.Began:
			Touch touch0 = Input.GetTouch (0);
			Touch touch1 = Input.GetTouch (1);
			previousPinchDistance = Vector3.Distance (touch0.position, touch1.position);
			touchPhase = TouchPhase.Pinched;
			break;
		case TouchPhase.Pinched:
			if (Input.touchCount < 2)
				touchPhase = TouchPhase.Untouched;
			touch0 = Input.GetTouch (0);
			touch1 = Input.GetTouch (1);
			float pinchDistance = Vector3.Distance (touch0.position, touch1.position);
			cameraDistance = Mathf.Clamp (cameraDistance * (previousPinchDistance / pinchDistance), 1f, 10f);
			previousPinchDistance = pinchDistance;
			break;
		default:
			break;
		}

		Vector3 acceleration = Input.acceleration;

		acceleration.x = Mathf.Floor (acceleration.x * 180f);
		acceleration.y = Mathf.Floor (acceleration.y * 180f);
		acceleration.z = Mathf.Clamp (Mathf.Floor (acceleration.z * 180f), -70f, 70f);

		Vector3 lookPosition = targetTransform.position + offset;
		Vector3 relativePosition = Quaternion.Euler (acceleration.z, acceleration.x, 0f) * new Vector3 (0f, 0f, cameraDistance);
		transform.position = Vector3.Lerp (transform.position, lookPosition + relativePosition, 5f * Time.deltaTime);
		transform.LookAt (lookPosition);
	}
}
