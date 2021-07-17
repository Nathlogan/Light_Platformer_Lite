using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightProperties : MonoBehaviour
{
    public GameObject currentTarget;
    public Dictionary<GameObject, Light> lightTargets = new Dictionary<GameObject, Light>();

    public bool activeLight;

    // Variables for the light system
    [Header("Light System Properties:")]
    [Tooltip("Power limit of the platform light")]
    [Range(5f, 100f)]
    public float maxColorIntensity = 50f;
    [Tooltip("Power limit of the neutral light")]
    [Range(5f, 100f)]
    public float maxNeutralIntensity = 50f;
    [Tooltip("Rate at which the current power is drained")]
    [Range(-20f, -5f)]
    public float powerDrain = -5f;
    [Tooltip("Rate at which the platform light builds intensity while powered")]
    [Range(5f, 20f)]
    public float  powerRate = 5f;
    [Tooltip("Rate at which the platform light builds intensity while unpowered")]
    [Range(5f, 20f)]
    public float unpoweredRate = 5f;
    [Tooltip("Rate at which a color drains the current intensity of the platform")]
    [Range(-100f, 5f)]
    public float drainRate = -20f;
}
