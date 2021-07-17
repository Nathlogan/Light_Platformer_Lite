using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShift : MonoBehaviour
{
    public LightProperties lightProperties;
    public PlatformPowerControl activeLights;

    private Light[] platformLights;

    private void Awake()
    {
        lightProperties = GameObject.Find("XR Rig/Camera Offset/RightHand Controller/LightSystems")
            .GetComponent<LightProperties>();
        activeLights = GameObject.Find("XR Rig").GetComponentInChildren<PlatformPowerControl>();

    }

    // Start is called before the first frame update
    void Start()
    {
        platformLights = GetComponentsInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!activeLights.platformLights.ContainsKey(platformLights[0]) && platformLights[0].color != Color.white)
        {
            platformLights[0].intensity += lightProperties.powerDrain * Time.deltaTime;
            platformLights[1].intensity = platformLights[0].intensity;
        }

        if (platformLights[0].intensity == 0)
        {
            platformLights[0].color = Color.white;
            platformLights[1].color = Color.white;
        }

        if (platformLights[0].color == Color.white 
            && platformLights[0].intensity <= lightProperties.maxNeutralIntensity 
            && !lightProperties.activeLight)
        {
            platformLights[0].intensity += lightProperties.unpoweredRate * Time.fixedDeltaTime;
            platformLights[1].intensity = platformLights[0].intensity;
        }
    }
}
