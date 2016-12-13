using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SimonGame : MonoBehaviour {

	public GameObject jp1;
	public GameObject jp2;
	public GameObject jp3;
	public GameObject jp4;
	public GameObject jp5;

    public Text progression;

	public GameObject alienPos1; // bras different
	public GameObject alienPos2; // jambes écarté
	public GameObject alienPos3; // dab
	public GameObject alienPos4; // bras en l'air

	public static bool search = false;
	public static int numPos = -1;

	private List<GameObject> alienPosList = new List<GameObject>();
	private List<int> simonSequenceList = new List<int>();

	bool astroPos1Correct = false;
	bool astroPos2Correct = false;
	bool astroPos3Correct = false;
	bool astroPos4Correct = false;
	int i,j;

	private AudioSource audiosource;
	public AudioClip lose;
	public AudioClip win;

	// Use this for initialization
	void Start () {
       // progression = GetComponent<Text>();
        progression.text = "0/1";
        Debug.Log(progression);
		audiosource = GetComponent<AudioSource>();
		i = 0;
		j = 0;
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
		for(int k = 0;k < 10; k++)
		{

			simonSequenceList.Add(Random.Range(0, 4000)/1000);
		}


	}

	void YouLose()
	{
		audiosource.PlayOneShot (lose);
	}
	void YouWin()
	{
		audiosource.PlayOneShot (win);
	}

	void SimonSequence()
	{
		
		if (!search && numPos ==-1) {

			alienPosList[simonSequenceList[i]].SetActive(true);
					search = true;
			}
		if (!search && numPos != -1) {
			
			if (numPos != simonSequenceList [j]) {
				Debug.Log ("BAD POSITION ! Voulu " + simonSequenceList [j] + " capté " + numPos);
				search = true;
				//son lose + jauge descent
			} else {
                //continu
                Debug.Log ("BONNE POSITION");
				if (i == 9 && j == 9) {
					//win GAME
				}
				else if (i == j) {
					alienPosList[simonSequenceList[i]].SetActive(false);
					i++;
					j = 0;
					alienPosList[simonSequenceList[i]].SetActive(true);
					search = true;
					// son applause sequence suivante
				}
				else if(i > j)
				{
					j++;
					search = true;

					//gling son
				}
			}
			numPos = -1;
            progression.text = (j).ToString() + "/" + (i+1).ToString();
        }

	}


	// Update is called once per frame
	void Update () {

		SimonSequence ();

	}
}
