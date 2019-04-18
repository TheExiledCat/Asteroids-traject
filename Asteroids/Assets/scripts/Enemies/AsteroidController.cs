
using UnityEngine;

public class AsteroidController : Enemy
{
    public int iFrags;
    [SerializeField]
    float fMinSpeed, fMaxSpeed;
    public GameObject aSmall, aNormal;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (iFrags == 2)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
            transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
            Locate();
        }
       
       
        Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);
    }
    private void Update()
    {
        rb.velocity= transform.right * Random.Range(fMinSpeed, fMaxSpeed);
        CheckBorder();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("HIT");
        if (collision.CompareTag("bullet"))
        {
            if (collision.gameObject.GetComponent<NormalBulletController>().type != 2)
            {
                Destroy(collision.gameObject);
                switch (iFrags)
                {
                    case 0:
                        {
                            Destroy(gameObject);
                            break;
                        }
                    case 1:
                        {
                            GameObject cluster = Instantiate(aSmall, transform.position, transform.rotation);
                            GameObject cluster1 = Instantiate(aSmall, transform.position, Quaternion.identity);
                            cluster1.transform.Rotate(0, 0, -40f);
                            Destroy(gameObject);
                            break;
                        }
                    case 2:
                        {
                             GameObject cluster = Instantiate(aNormal, transform.position, transform.rotation);
                             GameObject cluster1 = Instantiate(aNormal, transform.position, transform.rotation);
                            cluster1.transform.Rotate(0, 0, -20f);
                            Destroy(gameObject);
                            break;
                        }
                }
            }
        }
    }
    
}
