using UnityEngine;
using INAH.Rupestre.Animations;
using INAH.Rupestre.Interactions;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    List<Item> items; 

    Animater animater;

    private void Awake()
    {
        items = new List<Item>();

        animater = GetComponent<Animater>();
    }

    public void AddToInventory(Interactable interactable)
    {
        Pickable item = (Pickable)interactable;
        animater.PickUpItem(item.DetachMesh());
        items.Add(item.GetItem);
        Destroy(item.gameObject);
    }
}

[System.Serializable]
public class Item
{
    public string name;
}