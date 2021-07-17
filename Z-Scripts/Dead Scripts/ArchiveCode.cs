using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchiveCode : MonoBehaviour
{
    /*
    //platformLight = lightProperties.currentTarget.GetComponentInChildren<Light>();
    if (colorValues.colorWheel[colorValues.currentColor] != platformLight.color)
    { // If powering the platform with a different color than the current

        // Drain the current power from the platform
        platformLight.intensity += lightProperties.drainRate * Time.fixedDeltaTime;

        if (platformLight.intensity == 0)
        { // Switch color after all power has drained

            platformLight.color = colorValues.colorWheel[colorValues.currentColor];
            lightProperties.currentTarget.transform
                .Find("Orb").GetComponent<Renderer>().material.SetColor("_EmissionColor", platformLight.color);
        }
    }
    // As long as power is being supplied to the platform, add power of current color
    if (platformLight.intensity <= lightProperties.maxIntensity)
        platformLight.intensity += lightProperties.powerRate * Time.fixedDeltaTime;
    */
}
