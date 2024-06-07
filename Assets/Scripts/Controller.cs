using UnityEngine;

[RequireComponent(typeof(Walker))]
public class Controller : MonoBehaviour
{
    Walker walker;
    Vector3 controlAxis;

    private void Awake()
    {
        walker = GetComponent<Walker>();
    }

    private void Update()
    {
        controlAxis.x = Input.GetAxis("Horizontal");
        controlAxis.z = Input.GetAxis("Vertical");

        if (Mathf.RoundToInt(controlAxis.sqrMagnitude) > 0) { controlAxis.Normalize(); }
    }

    private void FixedUpdate()
    {
        if (controlAxis != Vector3.zero) { walker.CheckIfCliff(controlAxis); }
    }
}
