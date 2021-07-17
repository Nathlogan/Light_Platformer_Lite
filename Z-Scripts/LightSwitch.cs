using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    [Tooltip("Laser line object reference")]
    public XRInteractorLineVisual laserPointer;
    [Tooltip("Light Attatched to Laser Pointer")]
    public Light laserLight;
    [Tooltip("Flashlight object reference")]
    public Light flashlight;
    [Tooltip("Crystal light object reference")]
    public Light crystalLight;


    [HideInInspector]
    public int currentColor = 0;
    [HideInInspector]
    public Color[] colorWheel = { Color.white, Color.green, Color.blue, Color.red };

    private PlayerControls playerController;

    private Gradient setGradient;
    private GradientColorKey[] setCKey;
    private GradientAlphaKey[] setAKey;

    private bool _gripPressed;
    private bool _triggerPressed;

    private GameObject crystal;
    private GameObject crystalSpawner;
    private GameObject currentCrystal;
    private Material colorOrb;
    private LightProperties target;
    private PlatformMovement platformMovement;

    private void Awake()
    {
        InitializePlayerControls();
    }

    private void Start()
    {
        InitializeReferences();
        SetInitialStates();
    }

    /***
     *  Functions called on button press/Release
     *  
     *  Contents:
     *      void Laser_On()
     *      void Laser_Off()
     *      void Flashlight_On()
     *      void Flashlight_Off()
     *      void SpawnCrystal()
     *      void Move_Platform()
     *      void Toggle_Color()
     ***/

    // Right: Grip activated / Spawns a thin but long laser light
    private void Laser_On(InputAction.CallbackContext obj)
    {
        if (!_triggerPressed)
            laserPointer.gameObject.SetActive(true);

        _gripPressed = true;
    }
    private void Laser_Off(InputAction.CallbackContext obj)
    {
        laserPointer.gameObject.SetActive(false);
        _gripPressed = false;
    }

    // Right: Trigger activated / Spawns a wide but short area light
    private void Flashlight_On(InputAction.CallbackContext obj)
    {
        if (!_gripPressed)
            flashlight.gameObject.SetActive(true);

            _triggerPressed = true;
    }
    private void Flashlight_Off(InputAction.CallbackContext obj)
    {
        flashlight.gameObject.SetActive(false);
        _triggerPressed = false;
    }

    // Right: Grip + Trigger activated / Spawns a throwable area light, short range but affects 360 degrees
    private void SpawnCrystal(InputAction.CallbackContext obj)
    {
        crystal.SetActive(true);

        laserPointer.gameObject.SetActive(false);
        flashlight.gameObject.SetActive(false);

        if (currentCrystal != null)
            Destroy(currentCrystal);

        currentCrystal = Instantiate(crystal, crystalSpawner.transform.position, crystalSpawner.transform.rotation);

        crystal.SetActive(false);
    }

    // Right: secondary button / Flips the move direction of the currently selected platform
    private void Move_Platform(InputAction.CallbackContext obj)
    {
        if (target.currentTarget != null)
        {
            platformMovement = target.currentTarget.GetComponentInParent<PlatformMovement>();
            // Flip the platform's direction
            platformMovement.NextPlatform();
        }
    }

    // Right: primary button / Cycles the current color of the player's light
    private void Toggle_Color(InputAction.CallbackContext obj)
    {
        // Move to next color on the wheel
        currentColor++;

        // Cycle back to the beginning of the wheel
        if (currentColor >= colorWheel.Length)
            currentColor = 0;

        // Set Light Colors
        setCKey[0].color = colorWheel[currentColor];
        setCKey[1].color = colorWheel[currentColor];

        setGradient.SetKeys(setCKey, setAKey);

        laserPointer.validColorGradient = setGradient;
        laserPointer.invalidColorGradient = setGradient;
        laserLight.color = colorWheel[currentColor];
        flashlight.color = colorWheel[currentColor];
        crystalLight.color = colorWheel[currentColor];
        colorOrb.SetColor("_EmissionColor", colorWheel[currentColor]);
    }

    /***
     *  Initializing functions for runtime
     *  
     *  Contents:
     *      void InitializePlayerControls()
     *      void InitializeReferences()
     *      void SetInitialColorValues()
     *      void OnEnable()
     *      void OnDisable()
     ***/

    // Init the control map for the player
    private void InitializePlayerControls()
    {
        playerController = gameObject.GetComponentInParent<InitializeControls>().playerControls;

        playerController.RightControls.ToggleLaser.performed += Laser_On;
        playerController.RightControls.ToggleLaser.canceled += Laser_Off;

        playerController.RightControls.ToggleFlashlight.performed += Flashlight_On;
        playerController.RightControls.ToggleFlashlight.canceled += Flashlight_Off;

        playerController.RightControls.ToggleColor.performed += Toggle_Color;
        playerController.RightControls.MovePlatform.performed += Move_Platform;

        playerController.RightControls.SpawnCrystal.performed += SpawnCrystal;
    }

    // Init object references at runtime
    private void InitializeReferences()
    {
        crystalSpawner = gameObject.transform.Find("LightSystems/Crystal Spawner").gameObject;
        crystal = GameObject.Find("Crystal");
        target = gameObject.GetComponentInChildren<LightProperties>();
        colorOrb = gameObject.transform.Find("Color Orb").gameObject.GetComponent<Renderer>().material;
    }

    // Set the initial colors of materials and states of game objects
    private void SetInitialStates()
    {
        crystal.SetActive(false);
        laserPointer.gameObject.SetActive(false);
        flashlight.gameObject.SetActive(false);

        colorOrb.SetColor("_EmissionColor", colorWheel[currentColor]);
        setGradient = new Gradient();
        setCKey = new GradientColorKey[2];
        setAKey = new GradientAlphaKey[2];

        laserLight.color = colorWheel[currentColor];
        flashlight.color = colorWheel[currentColor];

        setCKey[0].color = colorWheel[currentColor];
        setCKey[0].time = 0.0f;
        setCKey[1].color = colorWheel[currentColor];
        setCKey[1].time = 1.0f;

        setAKey[0].alpha = 1.0f;
        setAKey[0].time = 0.0f;
        setAKey[1].alpha = 1.0f;
        setAKey[1].time = 1.0f;
    }

    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();

    }
}
