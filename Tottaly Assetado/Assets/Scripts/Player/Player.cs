using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [Header("Start Variables")]
    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator anim;

    [Header("Hearts")]
    public int health;

    public bool isAlive = true;
    public bool invulnerable = false;

    public GameObject H1;
    public GameObject H2;
    public GameObject H3;

    [Header("Movement Player")]
    public float maxSpeed;
    
    [Header("Jump Player")]
    public float forceJump;
    private bool isGround;
    private bool isJumping;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float radius = 0.2f;

    [Header("Fire")]
    public Transform bulletSpawn;
    public GameObject bulletObject;

    public float fireRate;
    public float nextFire;

    [Header("Coins")]
    public Text textCoins;
    public float coins;

    [Header("Chest Checkpoint")]
    public Transform checkpoint;

    public Transform Chest1;
    public Transform Chest2;

    [Header("Others")]
    public GameObject PanelVictory;

    [Header("Sounds")]
    public AudioSource audioJump;
    public AudioSource audioShoot;
    public AudioSource audioDie;
    public AudioSource audioCoin;
    public AudioSource audioSwin;
    public AudioSource audioEnd;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        textCoins.text = coins.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            //Movement Player
            float move = Input.GetAxis("Horizontal");

            anim.SetFloat("Speed", Mathf.Abs(move));

            body.velocity = new Vector2(move * maxSpeed, body.velocity.y);

            if ((move > 0 && sprite.flipX) || (move < 0 && !sprite.flipX))
            {
                Flip();
            }

            //Fire
            if (Input.GetKeyDown(KeyCode.Z) && Time.time > nextFire)
            {
                Fire();
                audioShoot.Play();
            }

            //Check Ground
            isGround = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);

            //Jumping
            if (isJumping)
            {
                audioJump.Play();
                body.AddForce(new Vector2(0, forceJump));
                isJumping = false;
            }

            if (!isGround)
            {
                anim.SetBool("Jump", true);
            }
            else
            {
                anim.SetBool("Jump", false);
            }
        }
        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
     }
       

    void Flip()
    {
        sprite.flipX = !sprite.flipX;

        if (!sprite.flipX)
        {
            bulletSpawn.position = new Vector3(this.transform.position.x + 0.8f, bulletSpawn.position.y, bulletSpawn.position.z);
        }
        else
        {
            bulletSpawn.position = new Vector3(this.transform.position.x - 0.87f, bulletSpawn.position.y, bulletSpawn.position.z);
        }
    }

    void Fire()
    {
        anim.SetTrigger("Attack");

        nextFire = Time.time + fireRate;

        GameObject cloneBullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);

        if (sprite.flipX)
        {
            cloneBullet.transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            checkpoint = Chest1;
        }

        if (collision.gameObject.CompareTag("Chest2"))
        {
            checkpoint = Chest2;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            coins ++;
            textCoins.text = coins.ToString();
            audioCoin.Play();
        }

        if (collision.gameObject.CompareTag("End"))
        {
            PanelVictory.SetActive(true);
            Time.timeScale = 0;
            audioEnd.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WaterTrigger"))
        {
            StartCoroutine(Damage());
            anim.SetTrigger("Death");
            Invoke("ReloadLevel", 1f);
            isAlive = false;

            H1.SetActive(false);
            H2.SetActive(false);
            H3.SetActive(false);

            audioSwin.Play();
            audioDie.Play();
        }
    }

    IEnumerator Damage()
    {
        for(float i = 0f;i < 1f; i += 0.1f)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        invulnerable = false;
    }

    public void DamagePlayer()
    {
        if (isAlive)
        {
            invulnerable = true;
            health--;
            StartCoroutine(Damage());

            if (health < 3)
            {
                H3.SetActive(false);
            }

            if (health < 2)
            {
                H2.SetActive(false);
            }

            if (health < 1)
            {
                anim.SetTrigger("Death");
                H1.SetActive(false);
                isAlive = false;

                Invoke("ReloadLevel", 2f);
            }
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
