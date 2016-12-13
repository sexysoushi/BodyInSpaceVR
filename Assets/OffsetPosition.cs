using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OffsetPosition : MonoBehaviour {

public GameObject vive;
public GameObject tete;

public List<GameObject> nodeKinectList;
public List<GameObject> nodeModelList;

private List<GameObject> T_;
private List<GameObject> T_1;
private List<GameObject> T_2;

void Start () {
T_ = new List<GameObject>();
T_1 = new List<GameObject>();
T_2 = new List<GameObject>();

Vector3 offset = new Vector3(tete.transform.position.x - vive.transform.position.x, tete.transform.position.y - vive.transform.position.y, tete.transform.position.z - vive.transform.position.z);

for (int i = 0; i < nodeKinectList.Count; i++)
{
T_1.Add(Instantiate<GameObject>(nodeKinectList[i]));
T_1[i].transform.position = T_1[i].transform.position - offset;
T_1[i].transform.rotation = nodeKinectList[i].transform.rotation;

T_2.Add(Instantiate<GameObject>(T_1[i]));
T_.Add(Instantiate<GameObject>(T_1[i]));
}
}

// Update is called once per frame
void Update () {

Vector3 offset = new Vector3(tete.transform.position.x - vive.transform.position.x, tete.transform.position.y - vive.transform.position.y, tete.transform.position.z - vive.transform.position.z);
//Vector3 offsetTete = new Vector3 (-0.2f, -0.05f, 0.05f);
Vector3 offsetTete = new Vector3(-0.2f, 0.1f, 0);
offset = offset + offsetTete;
for (int i = 0; i < nodeKinectList.Count; i++)
{
nodeModelList[i].transform.position = nodeKinectList[i].transform.position - offset;
nodeModelList[i].transform.rotation = nodeKinectList[i].transform.rotation;
		}	
		nodeModelList [3].transform.position = nodeModelList [3].transform.position + offsetTete;
/*
if (i == 8 || i == 9)
{
nodeModelList[i].transform.position = nodeModelList[i].transform.position + teteplacer;
}
else
{
nodeModelList[i].transform.position = nodeModelList[i].transform.position + corpsplacer;
}
}*/
for (int i = 0; i < nodeKinectList.Count; i++)
{
T_[i].transform.rotation = nodeKinectList[i].transform.rotation;
T_[i].transform.position = nodeKinectList[i].transform.position - offset;
}
}
}