using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class TestChild : MonoBehaviour
{
    public SteamVR_Action_Boolean bol;
    public Transform t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bol.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            t.parent = transform;
        }
    }
}
