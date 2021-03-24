using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
       
    }
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);

            Destroy(gameObject, 0.5f);
        }
    }
}
