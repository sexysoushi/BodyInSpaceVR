using UnityEngine;
using System.Collections;

public class BetterController : MonoBehaviour {

	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;

	private bool pickupFlag = false;
	public const bool triggerButtonOn = false;
	public GameObject flag;
	private Transform posFlagInit;

	private AudioSource audio;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
		posFlagInit = flag.transform;

		audio = GetComponent<AudioSource> ();
		audio.Stop ();
	}

	private void OnTriggerEnter(Collider c)
	{
		Debug.Log ("TOUCH flag");
		audio.Play ();
	}

	private void OnTriggerStay(Collider c)
	{
		if(device.GetPressDown (gripButton) && c.gameObject == flag) {
			//flag.transform.parent = device.transform;
			Debug.Log ("GRIP pressed and touch flag");
			pickupFlag = true;
			c.gameObject.transform.parent.localPosition = new Vector3 (device.transform.pos.x, device.transform.pos.y - 10.0f, device.transform.pos.z);
		}
	}
		
	// Update is called once per frame
	void Update () {
		
		if (device.GetPressUp (gripButton) && pickupFlag) {
			flag.transform.position = posFlagInit.position;
			pickupFlag = false;
		}

		if (device.GetPressDown (triggerButton)) {
			//triggerButtonOn = true;
		} else {
			//triggerButtonOn = false;
		}
	}
}
