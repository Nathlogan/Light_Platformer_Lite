using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinished : MonoBehaviour
{
    public GameStart runInfo;
    public AudioSource completionAudio;

    public Text[] times;
    public float bestTime = 0f;

    private float finalTime;
    private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        runInfo = GameObject.Find("StartPlatform").GetComponentInChildren<GameStart>();
        times = gameObject.transform.parent.GetComponentsInChildren<Text>();
        canvas = times[0].gameObject.transform.parent.gameObject;
        canvas.SetActive(false);
        completionAudio = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name.Equals("XR Rig"))
        {
            if (runInfo.activeRun)
            {
                if (!completionAudio.isPlaying)
                    completionAudio.Play();

                finalTime = Time.time - runInfo.startTime;

                if (bestTime == 0f || finalTime < bestTime)
                    bestTime = finalTime;

                times[0].text = "Run Time: " + Mathf.Floor(finalTime/60f) + "m " + Mathf.Round(finalTime%60) + "s";
                times[1].text = "Best Time: " + Mathf.Floor(bestTime / 60f) + "m " + Mathf.Round(bestTime % 60) + "s";

                canvas.SetActive(true);
            }
            //runInfo.activeRun = false;
            //runInfo.gameObject.transform.parent.gameObject.SetActive(!runInfo.activeRun);
        }
    }
}
