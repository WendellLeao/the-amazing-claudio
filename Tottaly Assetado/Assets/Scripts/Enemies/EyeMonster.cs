using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMonster : EnemyController
{
    public bool isGround = false;

    public float lives = 2;

    private float time = 0.0f;

    public float force;
    public float timer;
    void Start()
    {
        health = 2;
    }

    protected override void Update()
    {
        base.Update();
        if (isGround)

        {
            time += Time.deltaTime;

            if (time >= timer)
            {
                time = 0f;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(body.velocity.x, force), ForceMode2D.Impulse);
            }
        }     
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            body.velocity = new Vector2(speed, body.velocity.y);

            timer = 0.3f;
        }
        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
            timer = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
