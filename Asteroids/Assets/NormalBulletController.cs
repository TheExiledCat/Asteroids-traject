
using UnityEngine;

public class NormalBulletController : MonoBehaviour
{
    //Variables
    public float fMoveSpeed;
    public int type;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * fMoveSpeed * Time.deltaTime;
        switch (type)//check type kogel
        {
            case 0:
                {

                    break;
                }
            case 1:
                {

                    break;
                }
            case 2:
                {

                    break;
                }
        }

    }
}
