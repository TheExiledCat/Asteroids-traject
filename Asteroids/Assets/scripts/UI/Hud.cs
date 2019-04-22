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
            GUI.DrawTexture(new Rect(Screen.width/20*i+Screen.width/30, Screen.height/10,Screen.width/20,Screen.height/20),t,ScaleMode.ScaleToFit);
        }
    }
    
}
