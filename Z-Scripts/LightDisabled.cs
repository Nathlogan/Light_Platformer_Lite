using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDisabled : MonoBehaviour
{
    public LightProperties stateVariables;

    private PlatformPowerControl lightList;

    private void Start()
    {
        stateVariables = gameObject.GetComponentInParent<LightProperties>();
        lightList = this.GetComponentInParent<PlatformPowerControl>();
    }

    private void OnDisable()
    {
        stateVariables.currentTarget = null;
        stateVariables.activeLight = false;
        stateVariables.lightTargets.Clear();
        lightList.platformLights.Clear();
    }
}
