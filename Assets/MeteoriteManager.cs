using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MeteoriteManager : MonoBehaviour {

	public Text countText;
	float countDown = 100.0f;
	bool activeTransY = false;

	public List<GameObject> meteoritList = new List<GameObject>();
	private GameObject lastGate;

	//public const float vitesseAstronaut = 0.01f; //temp
	float vitesseAstro = 0.1f;
	float limitVitesseMax = 1f;
	float limitVitesseMin = 0.1f;

	float countSpawn = 0.0f;


	// Use this for initialization
	void Start () {
		lastGate = GameObject.FindGameObjectWithTag ("Player");
	}


	void SpawnMeteorite(Transform lastGatePos)
	{
		int i = Random.Range (0, meteoritList.Count);
		GameObject gate = (GameObject)Instantiate (meteoritList[i], new Vector3(lastGatePos.position.x - 50.0f, lastGatePos.position.y, lastGatePos.position.z), meteoritList[i].transform.rotation);
		gate.transform.parent = this.transform;
	}


	void DestroyMeteorit ()
	{
		GameObject g;
		g = GameObject.FindGameObjectWithTag ("gate");
		if(g.transform.localPosition.y < -10.0f)
		{
			Destroy (g);
		}

	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (countDown);
		//Debug.Log (countText.text);
		if(countText.text == "3")
		{
			countDown--;
		}
		if(countDown <= 70.0f && countDown > 30.0f)
		{
			countText.text = "2";
			countDown--;
		}
		if(countDown <= 30.0f && countDown >= 0.0f)
		{
			countText.text = "1";
			countDown--;
		}
		if(countDown <= 0.0f)
		{
			countText.text = "";
			countDown = 0.0f;
			activeTransY = true;
		}


		if(activeTransY)
		{
			this.transform.position = new Vector3 (this.transform.position.x + vitesseAstro, this.transform.position.y, this.transform.position.z);
			countSpawn++;

			if(countSpawn >= 700.0f)
			{
				SpawnMeteorite(lastGate.transform);
				countSpawn = 0.0f;
			}

		}

		//DestroyMeteorit ();
	}
}
