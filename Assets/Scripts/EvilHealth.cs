using UnityEngine;

public class EvilHealth : MonoBehaviour
{
    public float health = 100f;
    
    private bool isDead = false;
    
     void Update()
        {
            if (health <= 0f)
            {
                Die();
            }
        }
     
    void Die()
    {
        isDead = true;

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
   
}
