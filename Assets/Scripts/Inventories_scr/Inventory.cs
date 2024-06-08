using UnityEngine;
using INAH.Rupestre.Animations;
using System.Collections.Generic;

namespace INAH.Rupestre.Inventories
{
    public class Inventory : MonoBehaviour
    {
        List<Item> items;

        Animater animater;

        public int GetTotalItems => items.Count;
        public bool HasSpace => items.Count < 12;

        private void Awake()
        {
            items = new List<Item>();

            animater = GetComponent<Animater>();
        }

        public void AddToInventory(Item item, Transform mesh)
        {
            items.Add(item);
            animater.PickUpItem(mesh);
        }
    }
}