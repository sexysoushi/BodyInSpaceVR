using UnityEngine;
using System.Collections;

public class ToucheJetPack : MonoBehaviour {

	//private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	//private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;

	private bool isClicked = true;

	//public GameObject hand;
	public GameObject world;
	public GameObject posVive;
	private Vector3 posControllerInit;
	public static float distanceInit;
	public static float comp;

    // Use this for initialization
    void Start() {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        world.SetActive(false);
      
	}



	void Update () {

		//hand.transform.position = this.transform.position;


		device = SteamVR_Controller.Input((int)trackedObject.index);
	
		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
			Application.LoadLevel ("ShowRoom");
		}

		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && isClicked)
		{
			posControllerInit = this.transform.position;
			//calcul distance initial
			distanceInit = Vector3.Distance(posControllerInit, posVive.transform.position);
			//demarre jeu
			world.SetActive(true);
			isClicked = false;
		}

		comp = Vector3.Distance(this.transform.position, posVive.transform.position);
		//comp = curDistance - distanceInit;
		//comp = Vector3.Distance(curDistance, distanceInit);
	}
}