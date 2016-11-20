using UnityEngine;
using System.Collections;

public class PlanetTrigger : MonoBehaviour {

	bool isInside = false;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider c) {
		
		isInside = true;

		Debug.Log ("touchey Doody!!!!");
		if(Input.GetKeyDown(KeyCode.A))
		{
			Application.LoadLevel ("Doodle");
		}
	}

	void OnTriggerExit(Collider c) {

		isInside = false;

		Debug.Log ("touchey Doody!!!!");
		if(Input.GetKeyDown(KeyCode.A))
		{
			Application.LoadLevel ("Doodle");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
