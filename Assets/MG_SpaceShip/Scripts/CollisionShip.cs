using UnityEngine;
using System.Collections;

public class CollisionShip : MonoBehaviour {
    
    void OnTriggerEnter(Collider c)
    {

        if (c.gameObject.name.Equals("ship"))
        {
            this.transform.parent.position = new Vector3(0, -50, 230);
        }
    }
	
}
