using UnityEngine;
using INAH.Rupestre.Inventories;

namespace INAH.Rupestre.Statistics
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] float baseSpeed = 3f;
        [SerializeField] float penaltyPerItem = 0.125f;
        [SerializeField] float totalEnergy = 100f;
        [SerializeField] float energyPerSecond= 1;
        [SerializeField] float energyPerItem = 0.083f;

        float currentEnergy;
        Inventory inventory;

        public float GetSpeed => baseSpeed - penaltyPerItem * inventory.GetTotalItems;
        public bool HasEnergyToWalk => currentEnergy > 0;

        private void Awake()
        {
            inventory = GetComponent<Inventory>();

            currentEnergy = totalEnergy;
        }

        public void DrainEnergy()
        {
            float energyToDrain = energyPerSecond * Time.deltaTime + energyPerItem * inventory.GetTotalItems * Time.deltaTime;
            currentEnergy -= energyToDrain;
        }
    }
}