using UnityEngine;

public class Enemy : Object
{
    public delegate void Hit();
    public static event Hit OnHit;
    
    public void Locate()
    {
        if (Random.Range(0, 1) < 0.5f)
        {
            transform.position = new Vector3(-85, Random.Range(-60, 60), 1);

        }
        else if (Random.Range(0, 1) < 1f)
        {
            transform.position = new Vector3(85, Random.Range(-60, 60), 1);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
            Debug.Log("score++");
        //OnHit();
    }



}
