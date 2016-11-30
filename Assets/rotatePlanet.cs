using UnityEngine;
using System.Collections;

public class rotatePlanet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.right * Time.deltaTime * 1.50f);
	}
}
