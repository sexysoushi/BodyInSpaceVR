using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateCircle : MonoBehaviour
{

    public List<GameObject> circleList;
    private Vector3 circlePos;
    private int randCircleOnList;
    private int randPosNumber;
    private float timer = 0.0f;
    private bool spawning = false;
    public static int nbCircleOnScene = 0;

    public static int difflvl;

    // Use this for initialization
    void Start()
    {
        nbCircleOnScene = 0;
        //default difficult lvl setting
        difflvl = 3;
    }

    void SpawnCircle()
    {
        //set spawning to true, to stop timer counting in the Update function
        spawning = true;

        //reset the timer to 0 so process can start over
        timer = 0.0f;

        randCircleOnList = (int)UnityEngine.Random.Range(0, circleList.Count);

        if (difflvl == 1)
        {
            circlePos.x = 0;
            circlePos.y = (int)UnityEngine.Random.Range(-10, 10);
            circlePos.z = (int)UnityEngine.Random.Range(0, 500);
        }

        if (difflvl == 2)
        {
            circlePos.x = (int)UnityEngine.Random.Range(-10, 10);
            circlePos.y = 0;
            circlePos.z = (int)UnityEngine.Random.Range(0, 500);
        }

        // circle position all around the map
        if (difflvl == 3)
        {
            circlePos.x = (int)UnityEngine.Random.Range(-150, 300);
            circlePos.y = (int)UnityEngine.Random.Range(-40, 40);
            circlePos.z = (int)UnityEngine.Random.Range(0, 500);
        }

        GameObject circleInst = (GameObject)Instantiate(circleList[randCircleOnList], circlePos, Quaternion.Euler(0, 90, 0));
        circleInst.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        circleInst.AddComponent<SphereCollider>();
        circleInst.GetComponent<SphereCollider>().isTrigger = true;

        nbCircleOnScene++;

        //set spawning back to false so timer may start again
        spawning = false;

    }

    // Update is called once per frame
    void Update()
    {
        //check if spawning at the moment, if not add to timer
        if (!spawning)
        {
            timer += Time.deltaTime;
        }

        //when timer reaches 2 seconds, call Spawn function
        if (timer >= 1 && nbCircleOnScene <= 1000)
        {
            SpawnCircle();
        }
    }
}
