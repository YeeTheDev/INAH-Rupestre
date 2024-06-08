using UnityEngine;

namespace INAH.Rupestre.Interactions
{
    public class Pickable : Interactable
    {
        [SerializeField] Item item;
        [SerializeField] Transform mesh;

        Inventory inventory;

        public Item GetItem => item;

        public override void Interact(Transform player)
        {
            if (inventory == null) { inventory = player.GetComponent<Inventory>(); }

            if (!inventory.HasSpace) { return; }

            canInteract = false;
            mesh.parent = null;

            inventory.AddToInventory(item, mesh);
            player.GetComponent<Interactor>().RemoveByIndex(transform);

            Destroy(gameObject);
        }
    }
}