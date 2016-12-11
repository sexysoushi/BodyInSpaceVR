using UnityEngine;
using System.Collections;

public class FollowController : MonoBehaviour {

	public GameObject controller;

	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (controller.transform.position.x, controller.transform.position.y, controller.transform.position.z);
	}
}
