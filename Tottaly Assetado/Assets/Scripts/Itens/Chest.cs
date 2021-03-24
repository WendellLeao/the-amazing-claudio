using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool isOpen = false;

    public GameObject coinsObject;

    public int coinsMax;
    public int coinsNumber;
    void Start()
    {
        
    }

    void Update()
    {
        if (isOpen)
        {
            GetComponent<Animator>().SetBool("ChestVoid", true);

            coinsNumber ++;

            if(coinsNumber <= coinsMax)
            {
                GameObject chestCoins = Instantiate(coinsObject, this.transform.position, this.transform.rotation);
            }
            else
            {
                coinsNumber = 11;
            }        
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("OpenChest", true);
            isOpen = true;
        }
    }
}
