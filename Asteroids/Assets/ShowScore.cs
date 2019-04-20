using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowScore : MonoBehaviour
{
    TextMeshProUGUI t;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        AsteroidController.OnHit += Score;
        t = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        t.text = "score" + "\n" + score.ToString("000000");
    }
    void Score()
    {
        Debug.Log("good job");
        score += 100;
    }
}
