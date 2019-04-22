using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Enemy
{
    public Vector3 target;
    int buffer=120;
    public float fMoveSpeed;
    public GameObject bullet;
    Vector3 startposition;
    bool bIsRetreating;
    // Start is called before the first frame update
    void Start()
    {
        Locate();
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (buffer > 0)
        {
            buffer--;
            transform.position = Vector3.MoveTowards(transform.position, target, fMoveSpeed * Time.deltaTime);
        }
        if (buffer == 0)
        {
            Invoke("Retreat", 0.5f);
            buffer = -1;
        }
        if (bIsRetreating)
        {
            transform.position = Vector3.MoveTowards(transform.position, startposition, fMoveSpeed * Time.deltaTime);
        }
    }
    void Retreat()
    {
        var shot = Instantiate(bullet, transform.position, transform.rotation);
        shot.transform.up = GameObject.FindGameObjectWithTag("Player").transform.position - shot.transform.position;
        bIsRetreating = true;
        Destroy(gameObject, 2f);
    }
}
