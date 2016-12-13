using UnityEngine;
using System.Collections;

public class PlanetTrigger : MonoBehaviour {

	public GameObject descriptionSimon;
	public GameObject descriptionDoodle;

	// Use this for initialization
	void Start () {
		descriptionSimon.SetActive(false);
		descriptionDoodle.SetActive(false);
	}

	void OnTriggerStay(Collider c) {
        //Debug.Log("trigger planet");
		if (c.gameObject.tag == "Simon") {
			descriptionSimon.SetActive (true);
            Debug.Log("trigger SIMON planet");
            if (BetterController.padButtonOn) {
                Debug.Log("TouchePad pressed for Simon");
				Application.LoadLevel ("Simon");
			}
		} 

		if (c.gameObject.tag == "Doodle") {
			descriptionDoodle.SetActive (true);
			if (BetterController.padButtonOn) {
				Application.LoadLevel ("Doodle");
			}
		} 
	}

    void OnTriggerExit(Collider c)
    {
        descriptionSimon.SetActive(false);
        descriptionDoodle.SetActive(false);
    }

        // Update is called once per frame
        void Update () {
	
	}
}
