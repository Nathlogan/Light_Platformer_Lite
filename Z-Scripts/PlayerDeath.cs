using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public Button startButton;
    public GameStart runInfo;
    public LightProperties activeLights;
    public PlatformMovement targets;

    private GlobalPlatformInfo[] platformInfo;

    public Vector3 spawnPosition;
    public float killZone;

    private void Start()
    {
        activeLights = gameObject.GetComponentInChildren<LightProperties>();
        startButton = GameObject.Find("StartPlatform/GhostObjects").gameObject.GetComponentInChildren<Button>();
        runInfo = startButton.gameObject.GetComponent<GameStart>();

        platformInfo = new GlobalPlatformInfo[3];

        platformInfo[0] = GameObject.Find("Course 1").GetComponentInChildren<GlobalPlatformInfo>();
        platformInfo[1] = GameObject.Find("Course 2").GetComponentInChildren<GlobalPlatformInfo>();
        platformInfo[2] = GameObject.Find("Course 3").GetComponentInChildren<GlobalPlatformInfo>();

        spawnPosition = this.transform.position;
        killZone = Mathf.Min(platformInfo[0].lowestPlatform - 10f, platformInfo[1].lowestPlatform - 10f, platformInfo[2].lowestPlatform - 10f);

    }

    private void FixedUpdate()
    {
        if (this.transform.position.y <= killZone)
        {
            this.transform.parent = null;
            runInfo.activeRun = false;
            startButton.gameObject.transform.parent.gameObject.SetActive(!runInfo.activeRun);
            this.transform.position = spawnPosition;

            for (int k = 0; k < platformInfo.Length; k++)
            {
                for (int i = 0; i < platformInfo[k].platformCount; i++)
                {
                    GameObject tmp = platformInfo[k].gameObject.transform.GetChild(i).gameObject;
                    targets = tmp.GetComponentInChildren<PlatformMovement>();
                    tmp.transform.Find("Platform Base").gameObject.transform.localPosition = platformInfo[k].startingPositions[i];
                    tmp.GetComponentsInChildren<Light>()[0].color = Color.white;
                    tmp.GetComponentsInChildren<Light>()[1].color = Color.white;
                    targets.SetInitialTransforms();
                }
            }
        }
    }
}
