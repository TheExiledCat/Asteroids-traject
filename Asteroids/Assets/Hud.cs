using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Hud : MonoBehaviour
{
    public Texture t;
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Ship");
    }
    private void OnGUI ()
    {
        for(int i = 0; i < player.GetComponent<PlayerController>().lives; i++)
        {
            GUI.DrawTexture(new Rect(30*i+10, 40,25,25),t);
        }
    }
}
