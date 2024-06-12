using System.Collections.Generic;
using UnityEngine;
using INAH.Rupestre.Animations;

namespace INAH.Rupestre.Interactions
{
    public class Interactor : MonoBehaviour
    {
        Animater animater;
        List<Interactable> interactables = new List<Interactable>();

        private void Awake() => animater = GetComponent<Animater>();

        public bool TryToInteract()
        {
            if (interactables.Count > 0 && TryInteractableByPriority(out Interactable toInteract))
            {
                if (toInteract.Interact(transform))
                {
                    if (!animater.Rotated) { StartCoroutine(animater.LookAtTarget(toInteract.transform)); }

                    return true;
                }
            }

            return false;
        }

        private bool TryInteractableByPriority(out Interactable toInteract)
        {
            toInteract = null;

            int maxPriority = 0;
            foreach (Interactable interactable in interactables)
            {
                if (interactable.CanInteract && interactable.GetPriority > maxPriority)
                {
                    maxPriority = interactable.GetPriority;
                    toInteract = interactable;
                }
            }

            return maxPriority > 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Interactable") && !IsTransformInList(other.transform))
            {
                interactables.Add(other.GetComponent<Interactable>());
            }
        }

        private bool IsTransformInList(Transform other)
        {
            if (interactables.Count < 1) { return false; }

            foreach (Interactable interactable in interactables)
            {
                if (interactable.transform == other) { return true; }
            }

            return false;
        }

        private void OnTriggerExit(Collider other) { if (other.CompareTag("Interactable")) { RemoveByIndex(other.transform); } }

        public void RemoveByIndex(Transform toRemove) => interactables.RemoveAt(GetIndexByTransform(toRemove));

        private int GetIndexByTransform(Transform toCheck)
        {
            int index = 0;
            foreach (Interactable interactable in interactables)
            {
                if (toCheck == interactable.transform) { return index; }

                index++;
            }

            return index;
        }
    }
}