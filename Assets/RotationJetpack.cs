using UnityEngine;
using System.Collections;

public class RotationJetpack : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * 50.0f, Space.World);
	}
}
