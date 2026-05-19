using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;
    public Transform Eyes;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = new Ray(Eyes.position, Eyes.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayer))
            {
                Debug.Log("Hit " + hit.transform.name);
                if (hit.collider.TryGetComponent<Item>(out Item item))
                {
                    item.Interact();
                }
            }
        }
    }
}
