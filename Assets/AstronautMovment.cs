using UnityEngine;
using System.Collections;

public class AstronautMovment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			this.transform.position = new Vector3 (this.transform.position.x + 1.0f, this.transform.position.y, this.transform.position.z);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.transform.position = new Vector3 (this.transform.position.x - 1.0f, this.transform.position.y, this.transform.position.z);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 1.0f, this.transform.position.z);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - 1.0f, this.transform.position.z);
		}

	}
}
