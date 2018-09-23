using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Controller : MonoBehaviour {

    public Text uiText;
    public int numberOfSafetyViolations;
    // Use this for initialization
    void Start () {
        if (Input.GetButton("A"))
        {
            
            Debug.Log("Input " + Input.GetButton("A"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Submit"))
        {   
            Debug.Log("SUbmit button clicked");
            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                if(hit.transform.tag == "SafetyViolation")
                {
                    Debug.Log("MADE IT HERE");
                    DestroyImmediate(hit.collider.gameObject);
                    if (GameObject.FindGameObjectsWithTag("SafetyViolation").Length <= 0)
                    {
                        uiText.text = "Level complete! FIRE DRILL! Exit the room.";
                        SceneManager.LoadSceneAsync("Evacuation");
                    }
                    DoObjectsExist();
                    
                }
                
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }
    public void DoObjectsExist()
    {
        GameObject[] violations = GameObject.FindGameObjectsWithTag("SafetyViolation");
        numberOfSafetyViolations = violations.Length - 1;

        if (numberOfSafetyViolations == 0)
        {
            uiText.text = "Level complete! FIRE DRILL! Exit the room.";
            SceneManager.LoadSceneAsync("Evacuation");
        }
        else return;
    }
}
