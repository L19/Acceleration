using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccelerationView : MonoBehaviour
{
	enum Coordinate {
		X,
		Y,
		Z
	}

	[SerializeField]
	Coordinate coodinate;

	Text text;
	Vector3 acceleration = Vector3.zero;

	void Start ()
	{
		text = GetComponent<Text> ();
	}

	void Update ()
	{
		acceleration = Input.acceleration;

		switch (coodinate) {
		case Coordinate.X:
			text.text = "X: " + acceleration.x;
			break;
		case Coordinate.Y:
			text.text = "Y: " + acceleration.y;
			break;
		case Coordinate.Z:
			text.text = "Z: " + acceleration.z;
			break;
		default:
			break;
		}
	}
}
