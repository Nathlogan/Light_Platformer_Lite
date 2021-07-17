using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackYMovement : MonoBehaviour
{
    public GameObject peggedPlatform;
    private void OnEnable()
    {
        Vector3 tmp = transform.position;
        tmp.x = peggedPlatform.transform.position.x;
        tmp.z = peggedPlatform.transform.position.z;
        transform.position = tmp;
    }
}
