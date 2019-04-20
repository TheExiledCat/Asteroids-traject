using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Texture t;
    GameObject player;

    
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }
    private void OnGUI ()
    {
        for(int i = 0; i < player.GetComponent<PlayerController>().lives; i++)
        {
            GUI.DrawTexture(new Rect(30*i+10, 40,25,25),t);
        }
    }
    
}
