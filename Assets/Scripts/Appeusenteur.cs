using UnityEngine;
using System.Collections;

public class Appeusenteur : MonoBehaviour {

	float rdmTime;
	// Use this for initialization
	void Start () {
		rdmTime = Random.Range (1.0f, 5.0f);
	}

	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.up * rdmTime * Time.deltaTime, Space.World);
		this.transform.position += Vector3.up * Time.deltaTime;
	}
}
