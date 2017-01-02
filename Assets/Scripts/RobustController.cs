using UnityEngine;
using System.Collections;

public class RobustController : MonoBehaviour {

	//private Valve.VR.EVRBu
	private SteamVR_Controller.Device device;
	private SteamVR_TrackedObject trackedObject;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
