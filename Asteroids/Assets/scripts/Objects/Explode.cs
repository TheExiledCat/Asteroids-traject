using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    
    public GameObject hitbox;
    CircleCollider2D hurtbox;
    // Start is called before the first frame update
    void Start()
    {
        
        hurtbox = hitbox.GetComponent<CircleCollider2D>();
    }

   
    public void Boom()
    {
        hurtbox.enabled = true;
        
    }
}

