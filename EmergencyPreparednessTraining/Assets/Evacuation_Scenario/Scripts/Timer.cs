using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public float time;
    public Text timerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        timerText.text = "Time: " + (int)time;
        if (time <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
	}
}
