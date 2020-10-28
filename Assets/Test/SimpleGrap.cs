using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class SimpleGrap : MonoBehaviour
{
    public Rigidbody firstHand,secondHand;
    public ConfigurableJoint fcj, scj;
    public SteamVR_Action_Boolean gripAction;

    public Vector2 grip, gripRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gripAction.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            transform.position = firstHand.transform.position;
            transform.rotation = firstHand.transform.rotation;
            fcj.connectedBody = firstHand;
            JointDrive jd = fcj.zDrive;
            jd.positionSpring = grip.x;
            fcj.zDrive = jd;
            fcj.yDrive = jd;
            fcj.xDrive = jd;
            jd = fcj.slerpDrive;
            jd.positionSpring = gripRot.x;
            fcj.slerpDrive = jd;
        }
        if (gripAction.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            fcj.connectedBody = null;
            JointDrive jd = fcj.zDrive;
            jd.positionSpring = 0;
            fcj.zDrive = jd;
            fcj.yDrive = jd;
            fcj.xDrive = jd;
            fcj.slerpDrive = jd;
        }

        if (gripAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            scj.connectedAnchor = Vector3.zero;
            scj.connectedBody = secondHand;
            scj.xMotion = ConfigurableJointMotion.Locked;
            scj.yMotion = ConfigurableJointMotion.Limited;
            scj.zMotion = ConfigurableJointMotion.Locked;
        }
        if (gripAction.GetStateUp(SteamVR_Input_Sources.LeftHand))
        {
            scj.connectedBody = null;
            JointDrive jd = fcj.zDrive;
            jd.positionSpring = 0;
            scj.zDrive = jd;
            scj.yDrive = jd;
            scj.xDrive = jd;
            scj.slerpDrive = jd;
            scj.xMotion = ConfigurableJointMotion.Free;
            scj.yMotion = ConfigurableJointMotion.Free;
            scj.zMotion = ConfigurableJointMotion.Free;
        }
    }
}
