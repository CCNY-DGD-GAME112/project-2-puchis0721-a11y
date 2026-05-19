using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public int cost;
    public float weight;
    public abstract void Use();

    public void Interact()
    {
        Inventory inv = Object.FindFirstObjectByType<Inventory>();
        if (inv != null)
        {
            inv.AddItem(this);
            Debug.Log($"Picked up {itemName}!");
            gameObject.SetActive(false);
        }
    }

}
