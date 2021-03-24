using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private Player player;

    public AudioSource audioDie;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!player.invulnerable)
            {
                audioDie.Play();
                player.DamagePlayer();
            }
        }
    }
}
