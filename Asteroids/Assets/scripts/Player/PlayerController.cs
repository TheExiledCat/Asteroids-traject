using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : Object
{
    //Variables
    SpriteRenderer sr;
    public AudioClip shot;
    public AudioClip lazer;
    AudioSource source;
    Rigidbody2D rb;
    public Weapons[] wWeapons;
    [SerializeField]
    float fMoveSpeed, fTurnSpeed;
    [HideInInspector]
    public Weapons wWeapon;
    float fMoveInX;
    float fMoveInY;
    int iShotBuffer;
    int iSelector = 0;
    public int lives;
    bool bIsInvincible = false;
    public float respawnTime;
    public Transform barrel;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        wWeapon = wWeapons[0];
        Debug.Log(wWeapon.name);
    }
    private void Update()
    {
        if (lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        CheckBorder();
        if (iShotBuffer > 0)
        {
            iShotBuffer--;
        }
        //Controls
        fMoveInX = Input.GetAxis("Horizontal");
        fMoveInY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (iSelector < wWeapons.Length - 1)
            {
                iSelector++;
            }
            else if (iSelector == wWeapons.Length - 1)
            {
                iSelector = 0;
            }

            wWeapon = wWeapons[iSelector];
            Debug.Log(wWeapon.name);
            Debug.Log(iSelector);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (iSelector > 0)
            {
                iSelector--;
            }
            else if (iSelector == 0)
            {
                iSelector = 2;
            }

            wWeapon = wWeapons[iSelector];
            Debug.Log(wWeapon.name);
            Debug.Log(iSelector);
        }
        //Movement
        //rb.AddForce(transform.up * fMoveSpeed * fMoveInY);

        transform.position += transform.up * fMoveInY * fMoveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -fMoveInX * fTurnSpeed);
        if (bIsInvincible)
        {
            Flicker();
        }
        else
        {
            sr.enabled = true;
        }
    }
    void Shoot()//function to shoot bullet type where the buffer is the cooldown for every shot in frames
    {
        if (iShotBuffer == 0)
        {
            Instantiate(wWeapon.bulletType, new Vector3(barrel.position.x, barrel.position.y, 0), transform.rotation);
            if (wWeapon == wWeapons[0])
            {
                iShotBuffer = 5;
                source.PlayOneShot(shot);

            }
            else if (wWeapon == wWeapons[1])
            {
                source.PlayOneShot(shot);
                iShotBuffer = 80;
            }else if (wWeapon == wWeapons[2])
            {
                source.PlayOneShot(lazer);
                iShotBuffer = 100;
            }

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            if (!bIsInvincible)
            {
                rb.velocity = Vector3.zero;
                transform.position = Vector3.zero;
                lives--;
                bIsInvincible = true;
                Invoke("Safe", respawnTime);
            }

        }
    }
    void Safe()
    {
        bIsInvincible = false;
    }
    void Flicker()
    {

        sr.enabled = !sr.enabled;
    }
}
