using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Object
{
    //Variables
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
    public int lives = 3;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wWeapon = wWeapons[0];
        Debug.Log(wWeapon.name);
    }
    private void Update()
    {
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
        rb.AddForce(transform.up * fMoveSpeed*fMoveInY);
        
            //transform.position += transform.up * fMoveInY * fMoveSpeed * Time.deltaTime;
            
        transform.Rotate(0, 0, -fMoveInX * fTurnSpeed);
        
    }
    void Shoot()//function to shoot bullet type
    {
        if (iShotBuffer == 0)
        {
            Instantiate(wWeapon.bulletType, new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y, 0), transform.rotation);
            if (wWeapon == wWeapons[0])
            {
                iShotBuffer = 5;
            }
            else if (wWeapon == wWeapons[1])
            {

                iShotBuffer = 80;
            }

        }


    }
}
