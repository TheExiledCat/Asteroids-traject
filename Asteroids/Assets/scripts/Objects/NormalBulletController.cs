
using UnityEngine;

public class NormalBulletController : MonoBehaviour
{
    //Variables
    public float fMoveSpeed;
    public int type;
    void Start()
    {
        Invoke("Destroyer", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * fMoveSpeed * Time.deltaTime;
       //check type kogel
    }
    void Destroyer()
    {
        Destroy(gameObject);
    }
}
