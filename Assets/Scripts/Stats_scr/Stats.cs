using UnityEngine;
using INAH.Rupestre.Inventories;

namespace INAH.Rupestre.Statistics
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] float baseSpeed = 3f;
        [SerializeField] float penaltyPerItem = 0.125f;

        Inventory inventory;

        private void Awake()
        {
            inventory = GetComponent<Inventory>();
        }

        public float GetSpeed => baseSpeed - penaltyPerItem * inventory.GetTotalItems;
    }
}