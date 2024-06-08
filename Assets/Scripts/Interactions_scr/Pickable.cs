using UnityEngine;

namespace INAH.Rupestre.Interactions
{
    public class Pickable : Interactable
    {
        [SerializeField] Transform mesh;
        [SerializeField] Item item;

        public Item GetItem => item;

        public override void Interact(Transform player)
        {
            canInteract = false;
        }

        public Transform DetachMesh()
        {
            mesh.parent = null;
            return mesh;
        }
    }
}