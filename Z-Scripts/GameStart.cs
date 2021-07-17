using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button startButton;

    public float startTime;

    public bool activeRun;

    // Start is called before the first frame update
    void Start()
    {
        startButton = this.GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        startTime = Time.time;
        gameObject.transform.parent.gameObject.SetActive(activeRun);
        activeRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
