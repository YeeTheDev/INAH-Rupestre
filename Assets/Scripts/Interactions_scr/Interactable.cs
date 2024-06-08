using UnityEngine;

namespace INAH.Rupestre.Interactions
{
    public abstract class Interactable : MonoBehaviour
    {
        [Tooltip("The highest priority interacts first")]
        [Range(1, 100)] [SerializeField] int priority;
        [SerializeField] protected bool canInteract;
        [SerializeField] protected bool isAnItem;
        [SerializeField] protected bool destroysOnInteraction;

        public int GetPriority => priority;
        public bool CanInteract => canInteract;
        public bool IsAnItem => isAnItem;
        public bool DestroysOnInteraction => destroysOnInteraction;

        public virtual void Interact(Transform player) { }
    }
}