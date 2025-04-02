using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartScript : MonoBehaviour
{
    [SerializeField] public Transform LeftHand;
    [SerializeField] public Transform RightHand;
    [SerializeField] public Transform LeftFoot;
    [SerializeField] public Transform RightFoot;

    public Transform GetLeftHand()
    {
        return LeftHand;
    }

    public Transform GetRightHand()
    {
        return RightHand;
    }

    public Transform GetLeftFoot() 
    {
        return LeftFoot;
    }

    public Transform GetRightFoot() 
    {
        return RightFoot;
    }
}
