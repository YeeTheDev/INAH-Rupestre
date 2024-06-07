using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animater))]
public class Walker : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float checkUpStartPoint = 0.5f;
    [SerializeField] float checkDownDistance = 0.75f;
    [SerializeField] LayerMask groundMask;

    Animater animater;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animater = GetComponent<Animater>();
    }

    public void CheckIfCliff(Vector3 controlAxis)
    {
        animater.RotateMesh(controlAxis);

        Vector3 checkerPoint = transform.position + Vector3.up * checkUpStartPoint + controlAxis;
        if (Physics.Raycast(checkerPoint, Vector3.down, checkDownDistance, groundMask)) { Walk(controlAxis); ; }
    }

    private void Walk(Vector3 direction)
    {
        Vector3 velocity = direction * speed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
