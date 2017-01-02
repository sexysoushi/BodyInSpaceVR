using UnityEngine;
using System.Collections;

public class LoadLvelTouchJetPack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    	private void OnTriggerEnter(Collider c)
	{
        Debug.Log("TOUCH");
        Application.LoadLevel ("DoodleStart");
		
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
