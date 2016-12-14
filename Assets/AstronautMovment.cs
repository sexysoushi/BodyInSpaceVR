using UnityEngine;
using System.Collections;

public class AstronautMovment : MonoBehaviour {

	public GameObject Hips;
	public GameObject Head;

	private Vector3 orientationInit;
	private Vector3 v;
	private int currAngle;
	private int coeff;

	// Use this for initialization
	void Start () {
		orientationInit = new Vector3(0,1,0);
		v = new Vector3(0,0,0);
	}
		
	// Update is called once per frame
	void Update () {

		v = (Hips.transform.position - Head.transform.position);
		currAngle = (int)(Mathf.Round((Mathf.Atan2(v.z,v.y) - Mathf.Atan2(orientationInit.z,orientationInit.y)) * Mathf.Rad2Deg/5));
		//Debug.Log (currAngle);

		if (Mathf.Abs (currAngle) != 36) {
			coeff = 36 - Mathf.Abs (currAngle);
			if(currAngle<0)
			{
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - (0.01f*coeff));
			}
			else
			{

				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + (0.01f*coeff));
			}

		}

		if(ToucheJetPack.comp < ToucheJetPack.distanceInit && ToucheJetPack.comp < 0.8f)
		{
			this.transform.position = new Vector3 (this.transform.position.x + (0.1f), this.transform.position.y , this.transform.position.z);
		}
		else if(ToucheJetPack.comp >  ToucheJetPack.distanceInit && ToucheJetPack.comp > 1.2f)
		{
			this.transform.position = new Vector3 (this.transform.position.x - (0.1f), this.transform.position.y, this.transform.position.z);
		}

		//Debug.Log ("comp : "+ToucheJetPack.comp + " distance : "+ ToucheJetPack.distanceInit);
	}
}
