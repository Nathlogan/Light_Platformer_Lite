using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackXMovement : MonoBehaviour
{
    public GameObject peggedPlatform;
    private void OnEnable()
    {
        Vector3 tmp = transform.position;
        tmp.y = peggedPlatform.transform.position.y;
        tmp.z = peggedPlatform.transform.position.z;
        transform.position = tmp;
    }
}
