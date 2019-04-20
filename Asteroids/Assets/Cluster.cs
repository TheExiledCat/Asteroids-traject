using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cluster : MonoBehaviour
{
    public GameObject particle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particle,transform.position,Quaternion.identity);
        Destroy(gameObject);
        
        if (collision.CompareTag("enemy"))
        {
            collision.GetComponent<AsteroidController>().BreakApart();
        }
        Destroy(transform.parent.gameObject);
    }
}
