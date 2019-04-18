using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

   
    protected void CheckBorder()
    {
        
        //screen wrap
        Vector2 pos = transform.position;
        if (transform.position.x <= screenLeft)
        {
            pos.x = screenRight - 1;
        }
        else if (transform.position.x >= screenRight)
        {
            pos.x = screenLeft + 1;
        }
        if (transform.position.y <= screenBottom)
        {
            pos.y = screenTop - 1;
        }
        else if (transform.position.y >= screenTop)
        {
            pos.y = screenBottom + 1;
        }
        transform.position = pos;
    }
}
