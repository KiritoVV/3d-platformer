using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "player")
            isFalling = true;
    }

    private void Update()
    {
        if(isFalling)
        {
            downSpeed += Time.deltaTime;
        }
    }
}
