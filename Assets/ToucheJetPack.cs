using UnityEngine;
using System.Collections;

public class ToucheJetPack : MonoBehaviour {

	//private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	//private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	//private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}

	private void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.tag == "jetpack")
		{
			Application.LoadLevel ("DoodleStart");
		}
			
	}

	void Update () {

		device = SteamVR_Controller.Input((int)trackedObject.index);
	
		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
			Application.LoadLevel ("ShowRoom");
		}

	
	}
}