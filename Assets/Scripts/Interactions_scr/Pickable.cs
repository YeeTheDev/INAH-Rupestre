using UnityEngine;

namespace INAH.Rupestre.Interactions
{
    public class Pickable : Interactable
    {
        [SerializeField] bool canPickUp;

        public override void Interact(Transform player)
        {
            Destroy(gameObject);
        }
    }
}