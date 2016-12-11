using UnityEngine;
using System.Collections;

public class RotateHermes : MonoBehaviour {

	float speed = 1.0f;
	bool Up=false;

	// Update is called once per frame
	void Update () {
		/*
		if (Up) {
			transform.Translate (Vector3.up * 0.02f);
			Up = false;
		} else {
			transform.Translate (-Vector3.up * 0.02f);
			Up = true;
		}
*/
		//transform.position += Vector3.up * Mathf.Sin (Time.deltaTime * speed);
		transform.Rotate (Vector3.up * Time.deltaTime * 50.0f, Space.World);
	}
}
