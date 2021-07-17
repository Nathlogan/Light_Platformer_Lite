using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandSettings : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;

    private GameObject handModel;

    // Start is called before the first frame update
    void Start()
    {
        TryInit();
    }

    void TryInit()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
            Debug.Log(item.name + item.characteristics);

        handModel = Instantiate(handModelPrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
