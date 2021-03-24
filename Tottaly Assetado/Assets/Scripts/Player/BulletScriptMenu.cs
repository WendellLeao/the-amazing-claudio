using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptMenu : MonoBehaviour
{
    private float timeDestroy;
    public float speed;

    public int damage;
    void Start()
    {
        timeDestroy = 1.0f;
        Destroy(gameObject, timeDestroy);
        damage = 1;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();

            if(enemy != null)
            {
                enemy.DamageEnemy(damage);
            }
        }

        Destroy(gameObject);
    }
}
