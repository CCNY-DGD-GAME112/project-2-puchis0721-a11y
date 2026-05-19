using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public float health = 100f;
    public Slider slider;
    
	private bool isDead = false;
  
    // Update is called once per frame
    void Update()
    {
		if (slider == null)
{
    Debug.Log("Slider is missing on " + gameObject.name, this);
    return;
}
  		if(isDead) return;

		 if (slider != null)
            slider.value = health;

		if (health <= 0f)
        {
            Die();
        }
    }

	public void Heal(float amount)
{
    if (isDead) return;

    health += amount;
    health = Mathf.Clamp(health, 0f, 100f);
}

    void Die()
    {
        if (isDead) return;
        isDead = true;
        
        if (CompareTag("Player"))
        {
            SceneManager.LoadScene("You Lose");
            return; 
        }
        
        Collider col = GetComponent<Collider>();
        if (col) col.enabled = false;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb) rb.linearVelocity = Vector3.zero;

        foreach (var script in GetComponents<MonoBehaviour>())
        {
            script.enabled = false;
        }

        Destroy(gameObject, 0.1f);
    }

    void OnCollisionEnter(Collision other)
    {
        if (isDead) return;

        if (other.gameObject.CompareTag("Hazard"))
            health -= 10f;
    }
    // Credits to SandS Arts and BMo for most lines of code for health and collision damage, many things had to be tweeked due to crazy bugs
}
