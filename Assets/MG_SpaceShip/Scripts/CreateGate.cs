using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateGate : MonoBehaviour
{

    public GameObject asteroids;
    public List<GameObject> gateList;
    private int randGateOnList;
    private Vector3 gatePos;
    private int randPosNumber;
    private float timer;
    private bool spawning = false;
    public static int nbGateOnScene = 0;
    public static int distance;

    // Use this for initialization
    void Start()
    {
        timer = 0.0f;
        distance = 80;
        GameObject astersInst = (GameObject)Instantiate(asteroids, new Vector3(-80, 200, this.transform.position.z + 600), Quaternion.Euler(0, 0, 297));
        astersInst.transform.parent = this.transform;
    }



    void SpawnGate()
    {
        //set spawning to true, to stop timer counting in the Update function
        spawning = true;

        //reset the timer to 0 so process can start over
        timer = 0.0f;

        randGateOnList = (int)UnityEngine.Random.Range(0, gateList.Count);

        gatePos.x = 0;
        gatePos.y = 0;

        if (GameObject.FindGameObjectWithTag("GATE"))
        {
            gatePos.z = GameObject.FindGameObjectWithTag("GATE").transform.position.z + distance;

        }
        else
        {
            gatePos.z = GameObject.Find("Ship container").transform.position.z + 100;
        }



        GameObject gateInst = (GameObject)Instantiate(gateList[randGateOnList], gatePos, Quaternion.Euler(0, 152, 0));
        gateInst.AddComponent<GatePassed>();
        gateInst.transform.parent = this.transform;
        nbGateOnScene++;

        //set spawning back to false so timer may start again
        spawning = false;

    }
    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z - 0.1f);

        //check if spawning at the moment, if not add to timer
        if (!spawning)
        {
            timer += Time.deltaTime;
        }

        //when timer reaches 2 seconds, call Spawn function
        if (timer >= 4 && nbGateOnScene <= 1)
        {
            SpawnGate();
        }
    }
}
