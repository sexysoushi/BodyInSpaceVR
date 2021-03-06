//using UnityEngine;
//using System.Collections;
//using Leap;

///// <summary>
///// 
///// </summary>
//public class LeapFly : MonoBehaviour
//{

//    Controller m_leapController;

	
//    // Use this for initialization
//    void Start()
//    {

//        m_leapController = GameObject.Find("HeadMountedHandController(Clone)").GetComponent<HandController>().GetLeapController();

//    }

//    void FixedUpdate()
//    {

//        Frame frame = m_leapController.Frame();

//        if (frame.Hands.Count >= 2)
//        {
//            //GetComponent<HandModel>().GetLeapHand();
//            Hand leftHand = GameObject.Find("PepperBaseCutLeftHand(Clone)").gameObject.GetComponent<HandModel>().GetLeapHand();
//            Hand rightHand = GameObject.Find("PepperBaseCutRightHand(Clone)").gameObject.GetComponent<HandModel>().GetLeapHand();
//            //Hand leftHand = GetLeftMostHand(frame);
//            //Hand rightHand = GetRightMostHand(frame);

//            // takes the average vector of the forward vector of the hands, used for the
//            // pitch of the plane.
//            Vector3 avgPalmForward = (frame.Hands[0].Direction.ToUnity() + frame.Hands[1].Direction.ToUnity()) * 0.5f;

//            Vector3 handDiff = leftHand.PalmPosition.ToUnityScaled() - rightHand.PalmPosition.ToUnityScaled();

//            Vector3 newRot = transform.parent.localRotation.eulerAngles;
//            newRot.z = -handDiff.y * 20.0f;

//            // adding the rot.z as a way to use banking (rolling) to turn.
//            newRot.y += handDiff.z * 3.0f - newRot.z * 0.03f * transform.parent.GetComponent<Rigidbody>().velocity.magnitude;
//            newRot.x = -(avgPalmForward.y - 0.1f) * 100.0f;

//            float forceMult = 20.0f;

//            // if closed fist, then stop the plane and slowly go backwards.
//            if (frame.Fingers.Count < 3)
//            {
//                forceMult = -3.0f;
//            }

//            transform.parent.localRotation = Quaternion.Slerp(transform.parent.localRotation, Quaternion.Euler(newRot), 0.1f);
//            transform.parent.GetComponent<Rigidbody>().velocity = transform.parent.forward * forceMult;
//        }

//    }

//}
