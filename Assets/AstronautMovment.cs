using UnityEngine;
using System.Collections;

public class AstronautMovment : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
		
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.DownArrow))
		{
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.01f);
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.01f);
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.position = new Vector3 (this.transform.position.x + 0.01f, this.transform.position.y , this.transform.position.z);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.position = new Vector3 (this.transform.position.x - 0.01f, this.transform.position.y, this.transform.position.z);
		}
	}
}
