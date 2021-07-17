using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryPlayer : MonoBehaviour
{ 
    public VerticalMovement verticalControls;

    private void Awake()
    {
        verticalControls = GameObject.Find("XR Rig").GetComponent<VerticalMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Equals("Crystal(Clone)"))
            other.transform.parent = transform;

        if (other.name.Equals("XR Rig"))
        {
            if (!verticalControls.jumpState)
            {
                other.transform.parent = transform;
                verticalControls.onPlatform = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("Crystal(Clone)"))
            other.transform.parent = null;

        if (other.name.Equals("XR Rig"))
        {
            other.transform.parent = null;
            verticalControls.onPlatform = false;
        }
    }
}
