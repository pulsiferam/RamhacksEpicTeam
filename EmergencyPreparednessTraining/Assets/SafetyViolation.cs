using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class SafetyViolation : MonoBehaviour {

    public Text uiText;
    public int numberOfSafetyViolations;
	// Use this for initialization
	void Start () {
        Debug.Log("Here");

	}

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        GameObject[] violations = GameObject.FindGameObjectsWithTag("SafetyViolation");
        numberOfSafetyViolations = violations.Length -1;

        if (gameObject.tag == "SafetyViolation")
        {
            DestroyImmediate(this.gameObject);
        }

        if (numberOfSafetyViolations == 0)
        {
            uiText.text = "Level complete! FIRE DRILL! Exit the room.";
            SceneManager.LoadSceneAsync("Evacuation");
        }
        else
        {
            uiText.text = "Crises averted! " + numberOfSafetyViolations + " safety items remaining";
        }
    }
}
