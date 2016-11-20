using UnityEngine;
using System.Collections;

public class RotateHermes : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.right * Time.deltaTime);
	}
}
