using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public Weapons[] wWeapons;
    float fMoveSpeed = 30;
    float fTurnSpeed = 4;
    Weapons wWeapon;
    float fMoveInX;
    float fMoveInY;
    int iShotBuffer;
    int iSelector = 0;
    public int lives = 3;
    private void Start()
    {
        wWeapon = wWeapons[0];
        Debug.Log(wWeapon.name);
    }
    private void Update()
    {
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
            if (iSelector < wWeapons.Length-1)
            {
                iSelector++;
            }else if (iSelector == wWeapons.Length-1)
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
        transform.position += transform.up*fMoveInY*fMoveSpeed*Time.deltaTime ;
        transform.Rotate(0, 0, -fMoveInX * fTurnSpeed);
        if (transform.position.x <= -70)
        {
            transform.position = new Vector3(69, transform.position.y, 1);
        }else if (transform.position.x >= 70)
        {
            transform.position = new Vector3(-69, transform.position.y, 1);
        }
        if (transform.position.y <= -52)
        {
            transform.position = new Vector3(transform.position.x, 51, 1);
        }
        else if (transform.position.y >= 52)
        {
            transform.position = new Vector3(transform.position.x, -51, 1);
        }
    }
    void Shoot()//function to shoot bullet type
    {
        if (iShotBuffer == 0)
        {
            Instantiate(wWeapon.bulletType, new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y, 0), transform.rotation);
            iShotBuffer = 5;
        }

       
    }
}
