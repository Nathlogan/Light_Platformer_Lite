using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public LightProperties lightProperties;

    [Header("Platform Settings:")]
    [Tooltip("Distance the platform can move along the x-axis * 2")]
    public float xSize = 5;
    [Tooltip("Distance the platform can move along the y-axis * 2")]
    public float ySize = 5;
    [Tooltip("Distance the platform can move along the z-axis * 2")]
    public float zSize = 5;
    [Tooltip("Max Speed of the platform")]
    [Range(0.5f, 5)]
    public float speed = 1f;
    [Tooltip("Time platform spends at a destination")]
    public float delay_time;

    [HideInInspector]
    public bool xState;
    [HideInInspector]
    public bool yState;
    [HideInInspector]
    public bool zState;
    [HideInInspector]
    public int bound_number = 0;

    // Target Postions for platform movement
    private Vector3[] xBounds;
    private Vector3[] yBounds;
    private Vector3[] zBounds;
    private Vector3 target_bound;

    // Limits on platform movement
    private float x_max;
    private float x_min;
    private float y_max;
    private float y_min;
    private float z_max;
    private float z_min;

    private float delay_start;
    private float speedDividend;
    private float tolerance;

    private bool inactivePlatform = true; // State of platform movement
    private Color currentColor; // Platform's current color

    private GameObject[] rails;
    private Light platformLight;

    private void Awake()
    {
        rails = new GameObject[3];
        xBounds = new Vector3[2];
        yBounds = new Vector3[2];
        zBounds = new Vector3[2];

        platformLight = gameObject.GetComponentInChildren<Light>();
        lightProperties = GameObject.Find("XR Rig/Camera Offset/RightHand Controller/LightSystems")
            .GetComponent<LightProperties>();

        rails[0] = gameObject.transform.parent.Find("Tracks/TrackX").gameObject;
        rails[1] = gameObject.transform.parent.Find("Tracks/TrackY").gameObject;
        rails[2] = gameObject.transform.parent.Find("Tracks/TrackZ").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetInitialStates();
        CalculateTransformLimits();
        SetInitialTransforms(); // Set the initial movement coordinates
        CheckBounds(); // Check for initialization issues
        tolerance = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentColor != platformLight.color)
        {
            // Check the color of the platform light to determine axis state
            CheckColorState();

            // Determine the state of the platforms
            rails[0].SetActive(xState);
            rails[1].SetActive(yState);
            rails[2].SetActive(zState);
        }

        if (xState)
        { // Platform moving on the x-axis
            target_bound = xBounds[bound_number];
            inactivePlatform = false;
        }
        else if (yState)
        { // Platform moving on the y-axis
            target_bound = yBounds[bound_number];
            inactivePlatform = false;
        }
        else if (zState)
        { // Platform moving on the z-axis
            target_bound = zBounds[bound_number];
            inactivePlatform = false;
        }
        else
            inactivePlatform = true;
            

        if (!inactivePlatform)
        { // Platform is moving
            if (transform.position != target_bound)
            { // Platform has not reached destination
                MovePlatform();
            }
            else
            {
                UpdateTarget();
            }
        }
    }

    /***
     *  Handles Movement controls of the platform
     *  
     *  Contents:
     *      void MovePlatform()
     *      void UpdateTarget()
     *      public void NextPlatform()
     *      void UpdateTransformTarget()
     ***/

    /// <summary>
    ///  Moves the platform towards the target Vector3
    /// </summary>
    void MovePlatform()
    {
        Vector3 heading = target_bound - transform.position;
        transform.position += (heading / heading.magnitude) * (platformLight.intensity/speedDividend) * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = target_bound;
            delay_start = Time.time;
        }
        UpdateTransformTarget();
    }

    /// <summary>
    /// Updates the current target coordinates of the platform
    /// </summary>
    void UpdateTarget()
    {
        if (xState || yState || zState)
        {
            if (Time.time - delay_start > delay_time)
            {
                NextPlatform();
            }
        }
    }

    /// <summary>
    /// Reverses the direction of the platform after reaching the target Vector3 
    /// </summary>
    public void NextPlatform()
    {
        bound_number++;
        if (bound_number >= 2)
        {
            bound_number = 0;
        }
    }

    /// <summary>
    /// Dynamically updates the transform targets of the platform to
    /// constrain movement to one axis at a time
    /// </summary>
    void UpdateTransformTarget()
    {
        if (xState)
        {
            // Set Y transform using current X and Z
            Vector3 min_tmp = transform.position;
            Vector3 max_tmp = transform.position;
            min_tmp.y = y_min;
            max_tmp.y = y_max;
            yBounds[0] = min_tmp;
            yBounds[1] = max_tmp;

            // Set Z transform using current X and Y
            min_tmp = transform.position;
            max_tmp = transform.position;
            min_tmp.z = z_min;
            max_tmp.z = z_max;
            zBounds[0] = min_tmp;
            zBounds[1] = max_tmp;
        }

        if (yState)
        {
            // Set X transform using current Y and Z
            Vector3 min_tmp = transform.position;
            Vector3 max_tmp = transform.position;
            min_tmp.x = x_min;
            max_tmp.x = x_max;
            xBounds[0] = min_tmp;
            xBounds[1] = max_tmp;

            // Set Z transform using current X and Y
            min_tmp = transform.position;
            max_tmp = transform.position;
            min_tmp.z = z_min;
            max_tmp.z = z_max;
            zBounds[0] = min_tmp;
            zBounds[1] = max_tmp;
        }
        if (zState)
        {
            // Set X transform using current Y and Z
            Vector3 min_tmp = transform.position;
            Vector3 max_tmp = transform.position;
            min_tmp.x = x_min;
            max_tmp.x = x_max;
            xBounds[0] = min_tmp;
            xBounds[1] = max_tmp;

            // Set Y transform using current X and Z
            min_tmp = transform.position;
            max_tmp = transform.position;
            min_tmp.y = y_min;
            max_tmp.y = y_max;
            yBounds[0] = min_tmp;
            yBounds[1] = max_tmp;
        }
    }

    /***
     *  Handle information retrieval and changing state booleans
     *  
     *  Contains:
     *      void CheckColorState()
     ***/

    /// <summary>
    /// Set State according to platform light color
    /// </summary>
    void CheckColorState()
    {
        // Set current color
        currentColor = platformLight.color;

        if (currentColor == Color.red)
        {
            xState = true;
            yState = false;
            zState = false;
        }
        else if (currentColor == Color.green)
        {
            xState = false;
            yState = true;
            zState = false;
        }
        else if (currentColor == Color.blue)
        {
            xState = false;
            yState = false;
            zState = true;
        }
        else
        {
            xState = false;
            yState = false;
            zState = false;
        }
    }

    /***
     *  Preprocessing of platform information
     *  Runs at progam 'start'
     *  
     *  Contents:
     *      void SetInitialValues()
     *      void CalculateTransformLimits()
     *      void SetInitialTransforms()
     *      void CheckBounds()
     ***/

    // Set the initial States of objects and variables
    void SetInitialStates()
    {
        currentColor = platformLight.color;
        speedDividend = lightProperties.maxColorIntensity / speed;
    }

    /// <summary>
    /// Determines the limits of the platform at start
    /// </summary>
    void CalculateTransformLimits()
    {
        Vector3 tmp = transform.parent.position;
        x_max = tmp.x + xSize;
        x_min = tmp.x - xSize;
        y_max = tmp.y + ySize;
        y_min = tmp.y - ySize;
        z_max = tmp.z + zSize;
        z_min = tmp.z - zSize;
    }

    /// <summary>
    /// Set the initial transform values for the platform
    /// !No Longer In Use!
    /// </summary>
    public void SetInitialTransforms()
    {
        /*
        Vector3 startPos = transform.position;
        startPos.x = transform.position.x + start_offset.x;
        startPos.y = transform.position.y + start_offset.y;
        startPos.z = transform.position.z + start_offset.z;

        transform.position = startPos;
        */

        Vector3 tmpx = transform.position;
        Vector3 tmpy = transform.position;
        Vector3 tmpz = transform.position;
        
        tmpx.x = x_min;
        tmpy.y = y_min;
        tmpz.z = z_min;
   
        xBounds[0] = tmpx;
        yBounds[0] = tmpy;
        zBounds[0] = tmpz;

        tmpx = transform.position;
        tmpy = transform.position;
        tmpz = transform.position;

        tmpx.x = x_max;
        tmpy.y = y_max;
        tmpz.z = z_max;

        xBounds[1] = tmpx;
        yBounds[1] = tmpy;
        zBounds[1] = tmpz;

    }

    /// <summary>
    /// Check for platform init issues at start
    /// </summary>
    void CheckBounds()
    {
        if (xBounds.Length != 2 || yBounds.Length != 2 || zBounds.Length != 2)
        {
            Debug.Log(gameObject.name + " -- Platform vectors should have size 2!");
        }
    }
    
}
