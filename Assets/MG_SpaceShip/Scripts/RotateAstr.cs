using UnityEngine;
using System.Collections;

public class RotateAstr : MonoBehaviour {

    public float degreesPerSecond = 80f;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Rotate(Vector3.one * 7.0f * Time.deltaTime, Space.World);
 
	}
}
