using UnityEngine;
using INAH.Rupestre.Animations;
using System.Collections.Generic;

namespace INAH.Rupestre.Inventories
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] float scalePerItem = 0.1f;
        [SerializeField] Transform backpackScaler;

        List<Item> items = new List<Item>();

        Animater animater;

        public int GetTotalItems => items.Count;
        public bool HasSpace => items.Count < 12;

        private void Awake() => animater = GetComponent<Animater>();

        public void AddToInventory(Item item, Transform mesh)
        {
            items.Add(item);
            animater.PickUpItem(mesh);
            AdjustBackpackSize();
        }

        private void AdjustBackpackSize()
        {
            backpackScaler.localScale = Vector3.one + Vector3.one * scalePerItem * items.Count ;
        }
    }
}