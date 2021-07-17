using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class VerticalMovement : MonoBehaviour
{
    public InitializeControls controllers;
    //private CharacterController character;
    private PlayerControls controls;
    private CharacterController character;

    public float gravity = -9.81f;
    public LayerMask groundLayer;

    [Header("Player Jump Values")]
    [Tooltip("Current Power stored up for the player's next jump")]
    public float jumpPower;
    [Tooltip("Cap for the player jump power")]
    [Range(1, 10)]
    public float powerCap = 2.0f;
    [Range(1, 10)]
    public float chargeRate = 3.0f;
    [Range(-20, 0)]
    public float drainRate = -10.0f;

    [Header("Player Leap Values")]
    public GameObject leapReference;
    public Vector3 finalDirection;
    [Tooltip("Current Power stored up for the player's next leap")]
    public float leapPower;
    public float leapSpeed;
    [Range(0.01f, 30)]
    public float leapClamp;
    [Range(0.01f, 10)]
    public float leapAcceleration = 4.0f;
    [Range(-10, -0.01f)]
    public float leapDeceleration = -4.0f;
    [Tooltip("Cap for the player jump power")]
    [Range(0.01f, 30)]
    public float leapPowerCap = 2.0f;
    [Range(0.01f, 60)]
    public float leapChargeRate = 3.0f;
    [Range(-1, -0.01f)]
    public float leapDrainRate = -10.0f;

    [Header("Monitor Variables:")]
    public bool isGrounded;
    public bool onPlatform;
    public float fallingSpeed;

    public GameObject rightHand;
    public Quaternion controllerDirection;

    [Header("Action States")]
    public bool jumpState;
    public bool leapState;
    public bool charging;
    public bool toggleGravityOff;
    public bool stuck;
    public bool leftGround;

    LineRenderer line;


    private void Awake()
    {
        controllers = this.GetComponent<InitializeControls>();
        character = this.GetComponent<CharacterController>();
        rightHand = gameObject.transform.Find("Camera Offset/RightHand Controller").gameObject;
        leapReference = rightHand.transform.Find("Leap").gameObject;
    }

    private void Start()
    {
        controls = controllers.playerControls;
        controls.LeftControls.Jump.performed += PlayerJump;
        controls.LeftControls.Jump.canceled += JumpCanceled;

        controls.RightControls.Leap.performed += PlayerLeap;
        controls.RightControls.Leap.canceled += LeapCanceled;

        controllerDirection = rightHand.transform.rotation;

        line = rightHand.GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.enabled = false;
    }

    private void LeapCanceled(InputAction.CallbackContext obj)
    {
        line.enabled = false;
        this.transform.parent = null;

        if (!isGrounded && charging)
        {
            leapState = false;
            leapPower = 0;
        }
        else if (charging)
        {
            finalDirection = leapReference.transform.position - rightHand.transform.position;
            if (leapPower < leapPowerCap)
                leapPower = 0;
        }
        charging = false;
    }

    private void PlayerLeap(InputAction.CallbackContext obj)
    {
        if (isGrounded && fallingSpeed < gravity/2)
        {
            charging = true;
        }
        
        //Debug.Log(leapDirection);
    }

    private void JumpCanceled(InputAction.CallbackContext obj)
    {
        jumpState = false;
    }

    private void PlayerJump(InputAction.CallbackContext obj)
    {
        if (isGrounded && fallingSpeed < gravity/2)
        {
            jumpState = true;
        }
    }

    private void Update()
    {
        if (!stuck)
            isGrounded = CheckIfGrounded();
        if (!jumpState)
        { // Add jump power while grounded
            if (jumpPower < powerCap && isGrounded)
                jumpPower += chargeRate * Time.deltaTime;
        }
        else
        { // Drain jump power if jumping
            if (jumpPower > 0)
                jumpPower += drainRate * Time.deltaTime;
        }

        if (charging)
        {
            leftGround = false;
            if (leapPower < leapPowerCap && isGrounded)
                leapPower += leapChargeRate * Time.deltaTime;
            if (leapPower >= leapPowerCap)
                leapState = true;

            createLeapLine();
        }
        else
        {
            if (leapState)
            {
                if (!leftGround && !isGrounded)
                    leftGround = true;

                if (leapPower > leapClamp)
                {
                    fallingSpeed = 0;
                    leapPower += leapDeceleration;
                }
                else
                {
                    if (leapPower > 0)
                        leapPower += leapDrainRate;
                    else
                        leapPower = 0;
                }

                if (isGrounded && (leapPower <= 0 || leftGround))
                {
                    leapState = false;
                    leapPower = 0;
                }

                if (leapState)
                    character.Move(finalDirection.normalized * leapPower * Time.deltaTime);
            }
        }

        if (isGrounded && fallingSpeed < gravity)
        { // Player at rest
            fallingSpeed = gravity;
        }
        else
        { // Player in the air
            if (!jumpState)
            { // Turn on gravity when not jumping
                fallingSpeed += gravity * Time.deltaTime;
            }
            else
            { // Cause player to jump
                if (jumpPower > 0)
                {
                    fallingSpeed = jumpPower;
                    if (onPlatform && !toggleGravityOff)
                    {
                        character.Move(character.transform.up * fallingSpeed * Time.deltaTime);
                    }
                }
                else
                    jumpState = false;
            }
        }

        if (!onPlatform && !toggleGravityOff)
            character.Move(character.transform.up * fallingSpeed * Time.deltaTime);
    }

    void createLeapLine()
    {
        line.enabled = true;
        line.startWidth = 0.06f;
        line.endWidth = 0.02f;

        line.SetPosition(0, rightHand.transform.position);

        Vector3 leapLine = new Vector3(leapReference.transform.position.x,
            leapReference.transform.position.y, leapReference.transform.position.z);
        line.SetPosition(1, leapLine);
    }

    bool CheckIfGrounded()
    {
        // Are we on the ground?
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }
}
