using UnityEngine;

public class Enemy : MonoBehaviour
{
  
    public void Locate(GameObject target)
    {
        if (Random.Range(0, 1)<0.5f)
        {
            transform.position = new Vector3(-90, Random.Range(-60, 60), 1);
            transform.LookAt(target.transform.position);
            transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
        }else if(Random.Range(0, 1) < 1f)
        {
            transform.position = new Vector3(90, Random.Range(-60, 60), 1);
            transform.LookAt(target.transform.position);
            transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
        }

    }
    
    
}
