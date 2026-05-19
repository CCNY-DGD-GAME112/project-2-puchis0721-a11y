using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{


	public TextMeshProUGUI timerText;
   	public float timer = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool triggered = false;

    // Update is called once per frame
    void Update()
    {
	    if (triggered) return;
	    timer -= Time.deltaTime;
	    timerText.text = timer.ToString("F2");
	    if (timer <= 0)
	    {
		    triggered = true;
	    }

		if (timer <= 0)
		{
			SceneManager.LoadScene("You Win");
		}
    }


	
}
