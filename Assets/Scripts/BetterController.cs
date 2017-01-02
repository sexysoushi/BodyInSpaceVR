using UnityEngine;
using System.Collections;

public class BetterController : MonoBehaviour {


    //private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    //private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;
    private SteamVR_TrackedController trackedController;

    private bool pickupFlag = false;
	public static bool padButtonOn = false;
	public GameObject flag;
    public GameObject vaisseau;
	private Vector3 posFlagInit;
    private Quaternion rotFlagInit;

    private AudioSource audio;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
        trackedController = GetComponent<SteamVR_TrackedController>();

        posFlagInit = flag.transform.position;
        rotFlagInit = flag.transform.rotation;

        audio = GetComponent<AudioSource> ();
		audio.Stop ();
	}

	private void OnTriggerEnter(Collider c)
	{
		//Debug.Log ("TOUCH flag");
		audio.Play ();
	}

	private void OnTriggerStay(Collider c)
	{
       // Debug.Log("GRIP pressed");
        // Debug.Log("GRIP pressed and touch flag");
        if (device.GetPressDown (SteamVR_Controller.ButtonMask.Grip) && c.gameObject == flag) {
            flag.GetComponent<BoxCollider>().enabled = false;
			flag.transform.parent = this.transform;
			//Debug.Log ("GRIP pressed and touch flag");
			pickupFlag = true;
			c.gameObject.transform.parent.localPosition = new Vector3 (device.transform.pos.x, device.transform.pos.y - 10.0f, device.transform.pos.z);
            ///c.gameObject.transform.localRotation = c.gameObject.transform.parent.localRotation;

        }
	}
		
	// Update is called once per frame
	void Update () {

        device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetPressUp (SteamVR_Controller.ButtonMask.Grip) && pickupFlag) {
            flag.transform.parent = vaisseau.transform;
            flag.transform.position = posFlagInit;
            flag.transform.rotation = rotFlagInit;
            flag.GetComponent<BoxCollider>().enabled = true;
            pickupFlag = false;
		}

		if (trackedController.padPressed) {
            Debug.Log("OUCHPAAAAAAAAAD");
            padButtonOn = true;

        } else {
            padButtonOn = false;
		}
	}
}
