using UnityEngine;
using System.Collections;

public class EasyController : MonoBehaviour {

	private SteamVR_TrackedController device;
	// Use this for initialization
	void Start () {
		device = GetComponent<SteamVR_TrackedController> ();
		device.TriggerClicked += Device_TriggerClicked;
	}

	void Device_TriggerClicked (object sender, ClickedEventArgs e)
	{
		Debug.Log ("trigger has been pre");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
