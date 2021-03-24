using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBullet : MonoBehaviour
{

    public GameObject bulletObject;
    public Transform bulletSpawn;

    public int tap = 0;

    public AudioSource audioShoot;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Fire()
    {
        if (tap == 0)
        {
            GameObject cloneBullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
            tap = 1;

            audioShoot.Play();
        }
    }
}
