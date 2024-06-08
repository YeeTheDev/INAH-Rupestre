using UnityEngine;
using INAH.Rupestre.Movement;
using INAH.Rupestre.Interactions;

namespace INAH.Rupestre.Controls
{
    [RequireComponent(typeof(Walker))]
    [RequireComponent(typeof(Interactor))]
    public class Controller : MonoBehaviour
    {
        Vector3 controlAxis;

        Walker walker;
        Interactor interactor;

        private void Awake()
        {
            walker = GetComponent<Walker>();
            interactor = GetComponent<Interactor>();
        }

        private void Update()
        {
            ReadControlAxis();
            ReadJButton();
        }

        private void FixedUpdate()
        {
            if (controlAxis != Vector3.zero) { walker.CheckIfCliff(controlAxis); }
        }

        private void ReadControlAxis()
        {
            controlAxis.x = Input.GetAxis("Horizontal");
            controlAxis.z = Input.GetAxis("Vertical");

            if (Mathf.RoundToInt(controlAxis.sqrMagnitude) > 0) { controlAxis.Normalize(); }
        }

        private void ReadJButton()
        {
            if (Input.GetKeyDown(KeyCode.J)) { interactor.TryToInteract(); }
        }
    }
}