using UnityEngine;
using System.Collections;

public class AliciaAnimation : MonoBehaviour
{
	Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();

		StartCoroutine ("ChangeAnimation");
	}

	IEnumerator ChangeAnimation ()
	{
		while (true) {

			int waitAnimationNumber = (int)Random.Range (0f, 5f);

			switch (waitAnimationNumber) {
			case 0:
				animator.SetTrigger ("Wait00");
				break;
			case 1:
				animator.SetTrigger ("Wait01");
				break;
			case 2:
				animator.SetTrigger ("Wait02");
				break;
			case 3:
				animator.SetTrigger ("Wait03");
				break;
			case 4:
				animator.SetTrigger ("Wait04");
				break;
			default:
				break;
			}

			yield return new WaitForSeconds (13f);
		}
	}

	void Update ()
	{

	}
}
