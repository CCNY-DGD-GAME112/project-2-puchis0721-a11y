using UnityEngine;
using TMPro;

public class HealPots : MonoBehaviour
{
    public Health playerHealth;

    public int maxUses = 3; // the max amount we can use
    private int currentUses; //what we currently have

    public float healAmount = 20f; //how much we can heal upon using an item
    public KeyCode healKey = KeyCode.E;

    public TextMeshProUGUI healText;

    void Start()
    {
        currentUses = maxUses;
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(healKey) && currentUses > 0)
        {
            playerHealth.Heal(healAmount);
            currentUses--;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (healText != null)
        {
            healText.text = healKey + " to heal: " + currentUses;
        }
    }
}

// this took a very long time for me to create, Credits with Brackeys and Dani Krossings for the inspiration of this line of code