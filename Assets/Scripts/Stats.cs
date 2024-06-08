using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] float baseSpeed = 3f;
    [SerializeField] float penaltyPerItem = 0.125f;

    Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    public float GetSpeed => baseSpeed - penaltyPerItem * inventory.GetTotalItems;
}
