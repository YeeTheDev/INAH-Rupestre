using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animater : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Transform meshTransform;

    public void RotateMesh(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        meshTransform.rotation = Quaternion.Lerp(meshTransform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
