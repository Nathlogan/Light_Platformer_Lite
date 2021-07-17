using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
    public VerticalMovement verticalInfo;

    public float speed = 1;
    public XRNode inputSource;
    public float additionalHeight = 0.2f;

    private XRRig rig;
    private Vector2 inputAxis;

    public InitializeControls controllers;
    public CharacterController character;

    private void Awake()
    {
        controllers = this.GetComponent<InitializeControls>();
        verticalInfo = this.GetComponent<VerticalMovement>();
        character = this.GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
        character = this.GetComponent<CharacterController>();
    }

    private void Start()
    {
        //character = controllers.character;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();

        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);
    }

    void CapsuleFollowHeadset()
    {
        character.height = rig.cameraInRigSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }

}

