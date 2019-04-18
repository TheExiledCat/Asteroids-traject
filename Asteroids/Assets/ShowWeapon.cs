using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowWeapon : MonoBehaviour
{
    TextMeshProUGUI t;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");//not hard coded
        t = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "[" + player.GetComponent<PlayerController>().wWeapon.name + "]";
    }
}
