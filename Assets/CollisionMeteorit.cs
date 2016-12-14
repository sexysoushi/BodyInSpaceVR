using UnityEngine;
using System.Collections;

public class CollisionMeteorit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision c)
	{
		//Debug.Log ("Collision ollision");
		if(c.gameObject.tag == "meteorite")
		{
			Debug.Log ("Meteorit collision");
			Application.LoadLevel ("DoodleStart");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
