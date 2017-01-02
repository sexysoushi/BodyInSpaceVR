using UnityEngine;
using System.Collections;

public class FaisceauRaycast : MonoBehaviour {

	private LineRenderer lineRenderer;



	// Use this for initialization
	void Start () {
	
		//lineRenderer = GetComponent<LineRenderer> ();
		//lineRenderer.SetPosition(0, transform.parent.localPosition);
		//lineRenderer.SetWidth (.1f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
		//lineRenderer.SetPosition(1, new Vector3(transform.parent.localPosition.x, transform.parent.localPosition.y + 20.0f, transform.parent.localPosition.z));
	
		Debug.DrawLine (transform.localPosition, new Vector3(transform.localPosition.x, transform.localPosition.y + 20.0f, transform.localPosition.z), Color.red);
	}
}
