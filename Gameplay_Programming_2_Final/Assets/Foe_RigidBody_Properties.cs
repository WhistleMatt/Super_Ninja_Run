using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foe_RigidBody_Properties : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
