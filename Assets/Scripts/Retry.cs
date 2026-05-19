using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("FPS");
        }
    }
}
