
using UnityEngine;

public class Split : Enemy
{
    int iFrags;
    

    private void Start()
    {
        Locate(GameObject.Find("Ship"));
        iFrags = (int)Random.Range(0, 3);
        switch (iFrags)
        {
            case 0:
                {
                    transform.localScale = new Vector3(1.5f, 1.5f, 1);
                    break;
                }
            case 1:
                {
                    transform.localScale = new Vector3(0.75f, 0.75f, 1);
                    break;
                }
            case 2:
                {
                    transform.localScale = new Vector3(0.4f, 0.4f, 1);
                    break;
                }
        }
       
    }
    
}
