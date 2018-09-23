using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class objectMovement : MonoBehaviour
{
    
    Vector3 distance;
    Vector3 offset;
   // private CharacterController characterController;
    //rivate float mvspeed = 8;
    //private float jump = 15;
    
    public Text uiText;
    public bool IsSelected;
    public int numTag;

    public void Start()
    {
        IsSelected = false;
        //characterController = GetComponent<CharacterController>();
        if (Input.GetButton("A"))
        {

            Debug.Log("Input " + Input.GetButton("A"));
        }
    }
    //private void OnMouseDown()
    //{
    //  distance= Camera.main.WorldToScreenPoint(transform.position);
    //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance.z));
    //}
    //private void OnMouseDrag()
    //{

    //  Vector3 CurrentPosition = new Vector3(Input.mousePosition.x , Input.mousePosition.y,distance.z);
    //Vector3 wposition = Camera.main.ScreenToWorldPoint(CurrentPosition)+offset;
    //transform.position = wposition;

    //}
    public float speed = 5.0f;
    public float rotationSpeed = 0.0f;
    private void moveobj()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        float jump = Input.GetAxis("Jump") * speed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
    }

    private void Update()
    {
        if (IsSelected == true)
        {
            moveobj();
        }
        if (Input.GetButton("Submit"))
        {
            Debug.Log("SUbmit button clicked");
            // Bit shift the index of the layer (8) to get a bit mask
            //int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
         // layerMask = ~layerMask;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,2))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                IsSelected = true;
                if (hit.transform.tag == "good")
                {

                    //if (hit.transform.tag == "good") { }
                    moveobj();
                }
                Debug.Log("hit good object");
               
            }

            else
            {
                Debug.Log("hit notgood object");
                //moveobj();

            }
            //Debug.Log(hit.transform.tag);
                if (GameObject.FindGameObjectsWithTag("good").Length == 0)
                {
                  uiText.text = "Level complete! Emergency prepardness kit is ready!";
                  SceneManager.LoadSceneAsync("Evacuation");
                }
              // DoObjectsExist();

            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }

        }
    }
       //
        //  if (IsSelected)
        //{
        //  float translation = Input.GetAxis("Vertical") * speed;
        //float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        // float jump = Input.GetAxis("Jump") * speed;
        //translation *= Time.deltaTime;
        //rotation *= Time.deltaTime;
        //transform.Translate(0, 0, translation);
        //transform.Rotate(0, 0, 0);
        //}
    

    




