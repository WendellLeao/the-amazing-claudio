using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBoss : MonoBehaviour
{
    public int health;

    public float distanceAttack;
    public float speed;

    protected bool isMoving = false;

    protected Rigidbody2D body;
    protected Animator anim;
    protected Transform player;
    protected SpriteRenderer sprite;

    public GameObject ColliderEndTable;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    protected float PlayerDistance()
    {
        return Vector2.Distance(player.position, transform.position);
    }

    protected void Flip()
    {
        sprite.flipX = !sprite.flipX;
        speed *= -1;
    }

    protected virtual void Update()
    {
        float distance = PlayerDistance();

        isMoving = (distance <= distanceAttack);

        if (isMoving)
        {
            if ((player.position.x > transform.position.x && sprite.flipX) ||
               (player.position.x < transform.position.x && !sprite.flipX))
            {
                Flip();
            }
        }
    }

    public void DamageEnemy(int damageBullet)
    {
        health -= damageBullet;

        StartCoroutine(Damage());

        if(health < 1)
        {
            Destroy(gameObject);
            ColliderEndTable.SetActive(true);
        }
    }

    IEnumerator Damage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
