using UnityEngine;
using System.Collections;

public class RetourMenu : MonoBehaviour {
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    private SteamVR_TrackedController trackedController;
    // Use this for initialization
    void Start () {

        trackedController = GetComponent<SteamVR_TrackedController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (trackedController.padPressed)
        {
            Application.LoadLevel("ShowRoom");

        }
    }
}
