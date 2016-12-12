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

		if (c.gameObject.tag == "Simon") {
			descriptionSimon.SetActive (true);
			if (BetterController.triggerButtonOn) {
				Application.LoadLevel ("Simon");
			}
		} else {
			descriptionSimon.SetActive(false);
		}

		if (c.gameObject.tag == "Doodle") {
			descriptionDoodle.SetActive (true);
			if (BetterController.triggerButtonOn) {
				Application.LoadLevel ("Doodle");
			}
		} else {
			descriptionDoodle.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
