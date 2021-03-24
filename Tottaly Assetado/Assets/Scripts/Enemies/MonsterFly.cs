using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFly : EnemyController
{
    void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();

        if (isMoving)
        {
            anim.SetBool("Attack", true);
            transform.position = Vector3.MoveTowards(transform.position, player.position, Mathf.Abs(speed) * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Attack", false);
        }

        if(health <= 0)
        {
            anim.SetBool("Death", true);
        }
    }
}
