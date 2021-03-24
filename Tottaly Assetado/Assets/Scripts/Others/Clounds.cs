using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clounds : MonoBehaviour
{
    public float speedClound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speedClound, 0, 0));
    }
}
