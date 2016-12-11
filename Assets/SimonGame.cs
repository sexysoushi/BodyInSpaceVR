using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimonGame : MonoBehaviour {

	public GameObject jp1;
	public GameObject jp2;
	public GameObject jp3;
	public GameObject jp4;
	public GameObject jp5;

	public GameObject alienPos1;
	public GameObject alienPos2;
	public GameObject alienPos3;
	public GameObject alienPos4;

	private List<GameObject> alienPosList = new List<GameObject>();
	private List<GameObject> simonSequenceList = new List<GameObject>();

	bool astroPos1Correct = false;
	bool astroPos2Correct = false;
	bool astroPos3Correct = false;
	bool astroPos4Correct = false;

	bool _s1 = false;
	bool _s2 = false;
	bool _s3 = false;
	bool _s4 = false;
	bool _s5 = false;
	bool _s6 = false;
	bool _s7 = false;
	bool _s8 = false;
	bool _s9 = false;


	// Use this for initialization
	void Awake () {

		jp1.SetActive (false);
		jp2.SetActive (false);
		jp3.SetActive (false);
		jp4.SetActive (false);
		jp5.SetActive (false);

		alienPosList.Add (alienPos1);
		alienPosList.Add (alienPos2);
		alienPosList.Add (alienPos3);
		alienPosList.Add (alienPos4);

		foreach(GameObject go in alienPosList)
		{
			go.SetActive (false);
		}

		//initialisation sequence Simon
		for(int i = 0; i < 10; i++)
		{
			simonSequenceList.Add(alienPosList[(Random.Range(0, alienPosList.Count))]);
		}

		SimonSequence1();
	}

	void SimonSequence1()
	{
		simonSequenceList [0].SetActive (true);

	}

	void SimonSequence2()
	{
		simonSequenceList [0].SetActive (false);
		simonSequenceList [1].SetActive (true);

	}

	void SimonSequence3()
	{
		simonSequenceList [1].SetActive (false);
		simonSequenceList [2].SetActive (true);

	}

	void SimonSequence4()
	{
		simonSequenceList [2].SetActive (false);
		simonSequenceList [3].SetActive (true);

	}

	void SimonSequence5()
	{
		simonSequenceList [3].SetActive (false);
		simonSequenceList [4].SetActive (true);

	}

	void SimonSequence6()
	{

		simonSequenceList [4].SetActive (false);
		simonSequenceList [5].SetActive (true);
	}

	void SimonSequence7()
	{

		simonSequenceList [5].SetActive (false);
		simonSequenceList [6].SetActive (true);
	}

	void SimonSequence8()
	{
		simonSequenceList [6].SetActive (false);
		simonSequenceList [7].SetActive (true);

	}

	void SimonSequence9()
	{

		simonSequenceList [7].SetActive (false);
		simonSequenceList [8].SetActive (true);
	}

	void SimonSequence10()
	{
		simonSequenceList [8].SetActive (false);
		simonSequenceList [9].SetActive (true);

	}


	// Update is called once per frame
	void Update () {

		if(_s1)
		{
			SimonSequence2 ();
		}

		if(_s2)
		{
			SimonSequence3 ();
		}

		if(_s3)
		{
			SimonSequence4 ();
		}

		if(_s4)
		{
			SimonSequence5 ();
		}

		if(_s5)
		{
			SimonSequence6 ();
		}

		if(_s6)
		{
			SimonSequence7 ();
		}

		if(_s7)
		{
			SimonSequence8 ();
		}

		if(_s8)
		{
			SimonSequence9 ();
		}

		if(_s9)
		{
			SimonSequence10 ();
		}


	}
}
