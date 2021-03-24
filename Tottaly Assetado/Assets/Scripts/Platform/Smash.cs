using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    public float speed;
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitSmash"))
        {
            speed = 2;
        }

        if (collision.gameObject.CompareTag("LimitSmashUp"))
        {
            speed = -7;
        }
    }
}
