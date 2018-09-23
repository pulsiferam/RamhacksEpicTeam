using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class objectMovement : MonoBehaviour
{

    Vector3 distance;
    Vector3 offset;
    float PositionX;
    float PositionY;
    float grabbedObjectSize;
    
    public bool IsSelected;

    public void Start()
    {
        IsSelected = false;
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
    
    private void Update()
    {
        if (IsSelected)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            float jump = Input.GetAxis("Jump") * speed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, 0, 0);
        }
    }
    
}



