using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, t);
    }

  
}
