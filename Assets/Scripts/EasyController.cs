using UnityEngine;
using System.Collections;

public class EasyController : MonoBehaviour {

	public GameObject f;
	private SteamVR_TrackedController device;
	// Use this for initialization
	void Start () {
		device = GetComponent<SteamVR_TrackedController> ();
		device.TriggerClicked += Device_TriggerClicked;
	}

	void Device_TriggerClicked (object sender, ClickedEventArgs e)
	{
		f.SetActive (true);
		Debug.Log ("trigger has been pre");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
