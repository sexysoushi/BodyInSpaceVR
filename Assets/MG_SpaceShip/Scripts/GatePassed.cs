using UnityEngine;
using System.Collections;

public class GatePassed : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name.Equals("ship"))
        {

            CreateGate.nbGateOnScene--;
            GameObject e = (GameObject)Instantiate(Resources.Load("test2"), GameObject.Find("LeapHandController").transform.position, Quaternion.identity);
            e.transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
            Destroy(this.gameObject);
        }
    }
}
