using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "PlayerLight")
        {
            Debug.Log("Light Detected");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
