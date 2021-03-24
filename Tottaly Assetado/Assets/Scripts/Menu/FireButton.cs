using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{
    public Camera cam;
    public Vector3 PosMouse;

    void Start()
    {
        
    }


    void Update()
    {
        PosMouse = cam.ScreenToWorldPoint(Input.mousePosition);
        PosMouse.z = transform.position.z;

        transform.right = (PosMouse - transform.position);
    }
}
