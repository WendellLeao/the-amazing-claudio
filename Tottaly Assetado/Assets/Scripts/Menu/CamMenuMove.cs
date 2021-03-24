using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMenuMove : MonoBehaviour
{
    public float speedCam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speedCam, 0, 0));
    }
}
