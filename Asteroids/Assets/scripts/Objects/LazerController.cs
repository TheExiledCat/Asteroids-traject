using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour
{
    BoxCollider2D bc2d;
    bool active = false;
    int buffer=1;
    // Start is called before the first frame update
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        
    }
    private void Update()
    {
        buffer--;
        if (buffer == 0)
        {
            bc2d.enabled = false;
        }
    }

}
