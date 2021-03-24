using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFlyBoss : EnemyController
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
    }
}
