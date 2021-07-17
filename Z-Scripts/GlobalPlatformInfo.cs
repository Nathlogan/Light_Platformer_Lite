using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPlatformInfo : MonoBehaviour
{
    public int platformCount;
    public float lowestPlatform;
    public Vector3[] startingPositions;

    // Start is called before the first frame update
    void Start()
    {
        platformCount = this.transform.childCount;
        startingPositions = new Vector3[platformCount];

        for (int i = 0; i < platformCount; i++)
        {
            GameObject tmp = this.transform.GetChild(i)
                .Find("Platform Base/CollisionObjects").gameObject;
            tmp.name = "Collision Objects (" + (i+1) + ")";
            tmp.GetComponentInChildren<Light>().gameObject.name 
                = "Sphere_Light (" + (i+1) + ")";

            startingPositions[i] = this.transform.GetChild(i).Find("Platform Base")
                .gameObject.transform.localPosition;

            float currY = this.transform.GetChild(i).transform.position.y;
            if (lowestPlatform > currY)
                lowestPlatform = currY;
        }
    }
}
