using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBridge : MonoBehaviour
{
    Rigidbody[] rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided");

            rb = GetComponentsInChildren<Rigidbody>();

            for (int i = 0; i < rb.Length; i++)
            {
                rb[i].isKinematic = false;
                rb[i].useGravity = true;
            }
        }
    }
}
