
using UnityEngine;

public class AsteroidController : Enemy
{
    public delegate void Hit();
    public static event Hit OnHit;
    public int iFrags;
    [SerializeField]
    float fMinSpeed, fMaxSpeed;
    public GameObject aSmall, aNormal;
    Rigidbody2D rb;
    public Manager mg;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (iFrags == 2)
        {
            Locate();
            transform.right = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;


        }



    }
    private void Update()
    {
        rb.velocity = transform.right * Random.Range(fMinSpeed, fMaxSpeed);
        CheckBorder();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("HIT");
        if (collision.CompareTag("bullet"))
        {
            OnHit();
            if (collision.gameObject.GetComponent<NormalBulletController>().type != 2)
            {
                Destroy(collision.gameObject);
                BreakApart();
            }
            else
            {
                BreakApart();
            }
        }
        if (collision.CompareTag("bomb"))
        {
            collision.GetComponent<Explode>().Boom();
            BreakApart();
        }
    }
    public void BreakApart()
    {

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
                    mg.SpawnAsteroids(1);
                    GameObject cluster = Instantiate(aNormal, transform.position, transform.rotation);
                    GameObject cluster1 = Instantiate(aNormal, transform.position, transform.rotation);
                    cluster1.transform.Rotate(0, 0, -20f);
                    Destroy(gameObject);
                    break;
                }
        }
    }

}
