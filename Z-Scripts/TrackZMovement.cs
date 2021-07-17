using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackZMovement : MonoBehaviour
{
    public GameObject peggedPlatform;
    private void OnEnable()
    {
        Vector3 tmp = transform.position;
        tmp.x = peggedPlatform.transform.position.x;
        tmp.y = peggedPlatform.transform.position.y;
        transform.position = tmp;
    }
}
