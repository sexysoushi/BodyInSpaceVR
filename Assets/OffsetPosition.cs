using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OffsetPosition : MonoBehaviour {

	public GameObject vive;
	public GameObject tete;

	public List<GameObject> nodeKinectList;
	public List<GameObject> nodeModelList;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Vector3 offset = new Vector3(tete.transform.position.x - vive.transform.position.x, tete.transform.position.y - vive.transform.position.y, tete.transform.position.z - vive.transform.position.z);

		for(int i = 0; i < nodeKinectList.Count; i++)
		{
			nodeModelList[i].transform.position = nodeKinectList[i].transform.position - offset;
			nodeModelList[i].transform.rotation = nodeKinectList[i].transform.rotation;
		}

	}
}
