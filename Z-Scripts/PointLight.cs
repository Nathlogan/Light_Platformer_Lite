using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLight : MonoBehaviour
{
    private LightProperties lightProperties;
    private PlatformPowerControl lightList;

    private void Start()
    {
        lightProperties = gameObject.GetComponentInParent<LightProperties>();
        lightList = gameObject.GetComponentInParent<PlatformPowerControl>();
    }

    private void OnTriggerStay(Collider other)
    {
        // Only affect "RayTargets" layer
        int layerMask = 1 << 13;
        // Set the direction of the raycast
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        // Information of hit platforms
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, 10, layerMask))
        { // Retrieve info for the first platform hit
            if (other.gameObject.layer != 21 && other.gameObject.layer != 16)
            {
                if (!lightProperties.lightTargets.ContainsKey(other.gameObject))
                {
                    lightProperties.lightTargets.Add(other.gameObject, this.GetComponent<Light>());
                    //Debug.Log("Added " + other.gameObject.name);
                }
                lightProperties.currentTarget = hit.collider.gameObject;
                lightProperties.activeLight = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lightProperties.lightTargets.Remove(other.gameObject);
        //Debug.Log("Removed " + other.gameObject.name);
        lightProperties.currentTarget = null;
        lightProperties.activeLight = false;
        if (lightList.platformLights != null)
            lightList.platformLights.Clear();
    }
}
