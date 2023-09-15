using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] int i;

    PlayerInventory pi;
    // Start is called before the first frame update
    void Start()
    {
        pi = PlayerInventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 0)
        {
            pi.isInventoryFull[i] = false;
        }
    }
}
