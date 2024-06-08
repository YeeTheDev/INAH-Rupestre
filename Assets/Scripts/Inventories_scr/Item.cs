using UnityEngine;

namespace INAH.Rupestre.Inventories
{
    [System.Serializable]
    public class Item
    {
        [SerializeField] string name;
        [SerializeField] Sprite icon;

        public string Name => name;
        public Sprite Icon => icon;
    }
}