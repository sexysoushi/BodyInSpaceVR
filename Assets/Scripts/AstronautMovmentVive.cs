using UnityEngine;
using System.Collections;

public class AstronautMovmentVive : MonoBehaviour {

		private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
		private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
		private SteamVR_TrackedObject trackedObject;
		private SteamVR_Controller.Device device;

		private GameObject pickup;

		// Use this for initialization
		void Start () {
			trackedObject = GetComponent<SteamVR_TrackedObject> ();
		}


		// Update is called once per frame
		void Update () {

			device = SteamVR_Controller.Input((int)trackedObject.index);
			if (device.GetAxis().x != 0 || device.GetAxis().y != 0) {
				//Debug.Log (device.GetAxis().x + " " + device.GetAxis().y);
			}

		//c'est pas ca
		if (device.GetAxis().x >= 0 && device.GetAxis().x <= 10) {
			//Debug.Log (device.GetAxis().x + " " + device.GetAxis().y);
		}

		if (device.GetAxis().y >= 0 && device.GetAxis().y <= 10) {
			//Debug.Log (device.GetAxis().x + " " + device.GetAxis().y);
		}



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
