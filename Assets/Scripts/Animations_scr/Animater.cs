using UnityEngine;
using System.Collections;

namespace INAH.Rupestre.Animations
{
    public class Animater : MonoBehaviour
    {
        [Header("Rotation animation")]
        [SerializeField] float rotationSpeed;
        [SerializeField] Transform meshTransform;
        [Header("Pick up animation")]
        [SerializeField] float pickUpTime;
        [SerializeField] Transform backpackCollectPoint;
        [SerializeField] AnimationCurve curve;
        [SerializeField] Vector3 finalItemScale;
        [Header("Talk animation")]
        [SerializeField] float rotateTime = 0.25f;

        bool rotated;
        Animator animator;

        public bool Rotated => rotated;

        private void Awake() => animator = GetComponent<Animator>();

        public void RotateMesh(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            meshTransform.rotation = Quaternion.Lerp(meshTransform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }

        public IEnumerator LookAtTarget(Transform target)
        {
            float time = 0;
            Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);

            while (time < rotateTime)
            {
                time += Time.deltaTime;
                meshTransform.rotation = Quaternion.Lerp(meshTransform.rotation, lookRotation, time / rotateTime);

                yield return new WaitForEndOfFrame();
            }

            rotated = true;
        }

        public void PickUpItem(Transform item) => StartCoroutine(PickUpAnimation(item));

        private IEnumerator PickUpAnimation(Transform item)
        {
            float time = 0;
            Vector3 initialPosition = item.position;
            Vector3 initialScale = item.localScale;

            while (time < pickUpTime)
            {
                yield return new WaitForEndOfFrame();

                time += Time.deltaTime;

                float lerpPoint = time / pickUpTime;

                MoveItem(item, initialPosition, lerpPoint);
                item.localScale = Vector3.Lerp(initialScale, finalItemScale, lerpPoint);
            }

            animator.SetTrigger("PickUp");
            Destroy(item.gameObject);
        }

        private void MoveItem(Transform item, Vector3 initialPosition, float lerpPoint)
        {
            Vector3 lerpPosition = Vector3.Lerp(initialPosition, backpackCollectPoint.position, lerpPoint);
            lerpPosition.y = curve.Evaluate(lerpPoint) + lerpPosition.y;

            item.position = lerpPosition;
        }
    }
}