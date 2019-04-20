using UnityEngine;

public class Enemy : Object
{
    
    
    public void Locate()
    {
        if (Random.Range(0, 2) < 0.5f)
        {
            transform.position = new Vector3(-85, Random.Range(-60, 60), 0);

        }
        else if (Random.Range(0, 2) < 1f)
        {
            transform.position = new Vector3(85, Random.Range(-60, 60), 0);
        }
        
    }
    



}
