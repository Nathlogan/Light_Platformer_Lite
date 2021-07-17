using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideLight : MonoBehaviour
{
    public LightProperties lightProperties;
    public PlatformPowerControl lightList;

    private void Start()
    {
        lightProperties = GameObject.Find("XR Rig/Camera Offset/RightHand Controller/LightSystems")
            .GetComponent<LightProperties>();
        lightList = gameObject.GetComponentInParent<PlatformPowerControl>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 13 && other.gameObject.layer != 21 && other.gameObject.layer != 16)
        {
            if (!lightProperties.lightTargets.ContainsKey(other.gameObject))
            {
                lightProperties.lightTargets.Add(other.gameObject, this.GetComponent<Light>());
                //Debug.Log("Added " + other.gameObject.name);
            }
            lightProperties.currentTarget = other.gameObject;
            lightProperties.activeLight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        lightProperties.lightTargets.Remove(other.gameObject);
        //Debug.Log("Removed " + other.gameObject.name);
        lightProperties.currentTarget = null;
        lightProperties.activeLight = false;
        if (lightList != null)
            lightList.platformLights.Clear();
    }

}
