using UnityEngine;

namespace INAH.Rupestre.Interactions
{
    public abstract class Interactable : MonoBehaviour
    {
        [Tooltip("The highest priority interacts first")]
        [Range(1, 100)] [SerializeField] int priority;
        [SerializeField] bool canInteract;
        [SerializeField] bool destroysOnInteraction;

        public int GetPriority => priority;
        public bool CanInteract => canInteract;
        public bool DestroysOnInteraction => destroysOnInteraction;

        public virtual void Interact(Transform player) { }
    }
}