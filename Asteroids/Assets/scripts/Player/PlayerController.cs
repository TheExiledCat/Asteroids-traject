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
            Debug.Log(wWeapon);
            Debug.Log(iSelector);
        }













        //Movement
        transform.position += transform.up*fMoveInY*fMoveSpeed*Time.deltaTime ;
        transform.Rotate(0, 0, -fMoveInX * fTurnSpeed);
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
