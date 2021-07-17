using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPowerControl : MonoBehaviour
{
    private LightSwitch colorValues;
    private LightProperties lightProperties;
    public Dictionary<Light, Light> platformLights = new Dictionary<Light, Light>();
    public Light currentSpotlight;

    // Start is called before the first frame update
    void Start()
    {
        lightProperties = this.GetComponent<LightProperties>();
        colorValues = gameObject.GetComponentInParent<LightSwitch>();
    }

    // Update is called once per frame
    void Update()
    {

        if (lightProperties.activeLight)
        {
            //Debug.Log(lightProperties.lightTargets.Count);
            foreach (KeyValuePair<GameObject, Light> entry in lightProperties.lightTargets)
            {
                if (!platformLights.ContainsKey(entry.Key.GetComponentInChildren<Light>()))
                {
                    platformLights.Add(entry.Key.GetComponentInChildren<Light>(), entry.Value);
                    //Debug.Log("Added Light from platform: " + entry.Key.name);
                }
            }

            foreach (KeyValuePair<Light, Light> entry in platformLights)
            {
                currentSpotlight = entry.Key.gameObject.transform.parent
                    .gameObject.transform.parent.Find("GhostObjects")
                    .GetComponentInChildren<Light>();
                if (entry.Value.color != entry.Key.color)
                { // Drain the current power from the platform
                    entry.Key.intensity += lightProperties.drainRate * Time.deltaTime;
                    currentSpotlight.intensity = entry.Key.intensity;

                    // Switch color after all power has drained
                    if (entry.Key.intensity == 0)
                    {
                        entry.Key.color = entry.Value.color;
                        currentSpotlight.color = entry.Value.color;
                    }
                }
                // As long as power is being supplied to the platform, add power of current color
                if (entry.Key.intensity <= lightProperties.maxColorIntensity)
                {
                    entry.Key.intensity += lightProperties.powerRate * Time.deltaTime;
                    currentSpotlight.intensity += lightProperties.powerRate * Time.deltaTime;
                }
            }
        }
    }
}
