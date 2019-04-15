
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class Menu : MonoBehaviour
{
    bool bIsEnabled;
    int buffer;
    private void Awake()
    {
        buffer = 60;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (buffer > 0)
        {
            buffer--;
        }
        if (buffer == 0)
        {
            bIsEnabled = !bIsEnabled;
            buffer = 60;
        }
        GetComponent<TextMeshProUGUI>().enabled=bIsEnabled;
    }
}
