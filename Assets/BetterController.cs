using UnityEngine;
using System.Collections;

public class BetterController : MonoBehaviour {
	public GameObject flag;
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;

	private GameObject pickup;

	public GameObject flagBefore;
	public GameObject flagAfter;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}




	private void OnTriggerEnter(Collider c)
	{
		Debug.Log ("TOUCH flag");
		pickup = c.gameObject;
	}

	private void OnTriggerStay(Collider c)
	{
		pickup = c.gameObject;
		if (device.GetPressDown (gripButton)) {
			//flag.transform.parent = device.transform;
			Debug.Log ("GRIP pressed and touch flag");
			pickup.transform.parent.position = new Vector3 (device.transform.pos.x, device.transform.pos.y, device.transform.pos.z);
		}
	}

	private void OnTriggerExit(Collider c)
	{
		pickup = null;
	}



	// Update is called once per frame
	void Update () {
	
		device = SteamVR_Controller.Input((int)trackedObject.index);
		if (device.GetAxis().x != 0 || device.GetAxis().y != 0) {
			//Debug.Log (device.GetAxis().x + " " + device.GetAxis().y);
		}
		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			//Debug.Log ("Trigger pressed");
			device.TriggerHapticPulse (700);
		}




	}
}
