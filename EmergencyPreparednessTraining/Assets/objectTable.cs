using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectTable : MonoBehaviour {
    public Text textui;
    // Use this for initialization
    public void Start()
    {
        textui.text = "Pick object for your emergency kit";
      
    }

    void OnTriggerEnter(Collider col)
    {
        
            if (col.tag == "good")
        {
            Debug.Log("collided");
            // Destroy(col.gameObject);
            textui.text = "Good Job";
           col.gameObject.tag = "notgood";
        }
        else
            textui.text = "You might die!";
    }

}
