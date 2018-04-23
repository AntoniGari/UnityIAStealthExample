using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Lean : MonoBehaviour {

	[SerializeField] private float maxLeanAngle = 20f;
	[SerializeField] private float leanSpeed = 100f;

	private bool m_LookRight = false;
	private bool m_LookLeft = false;
	private float curAngle = 0.0f;

	// Update is called once per frame
	void Update () {
		if (!CrossPlatformInputManager.GetButton ("LookLeft")) {
			m_LookRight = CrossPlatformInputManager.GetButton ("LookRight");
		}

		if (!CrossPlatformInputManager.GetButton ("LookRight")) {
			m_LookLeft = CrossPlatformInputManager.GetButton ("LookLeft");
		}

		//Calculate the camera angle
		if (m_LookRight) {
			curAngle = Mathf.MoveTowardsAngle (curAngle, maxLeanAngle, leanSpeed * Time.deltaTime);	
		} else if (m_LookLeft) {
			curAngle = Mathf.MoveTowardsAngle (curAngle, -maxLeanAngle, leanSpeed * Time.deltaTime);	
		} else {
			curAngle = Mathf.MoveTowardsAngle (curAngle, 0.0f, leanSpeed * Time.deltaTime);
		}

		transform.rotation = Quaternion.AngleAxis (curAngle, Vector3.forward);
	}
}
