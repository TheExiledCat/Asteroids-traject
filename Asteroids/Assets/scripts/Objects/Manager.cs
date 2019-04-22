using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject ufo;
    private void Start()
    {
        
        InvokeRepeating("SpawnUfo", 10f, 7f);
    }
    public void SpawnAsteroids(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            Instantiate(asteroid, transform.position, transform.rotation);
        }
    }
    void SpawnUfo()
    {
        Instantiate(ufo, transform.position, transform.rotation);
    }
}
