using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public List<Item> myItems = new List<Item>();


   public void AddItem(Item newItem)
   {
      myItems.Add(newItem);
      Debug.Log($"{newItem.itemName} added to Inventory!");
      
      newItem.gameObject.SetActive(false);
   }
}
