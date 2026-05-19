using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("FPS");
        }
    }
}
