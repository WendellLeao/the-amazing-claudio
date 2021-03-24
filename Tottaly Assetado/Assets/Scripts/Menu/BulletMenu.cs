using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMenu : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jogar"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scene01");
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Sair"))
        {
            Application.Quit();
            Destroy(gameObject);
        }

    }
}
