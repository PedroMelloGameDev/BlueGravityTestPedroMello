using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField] GameObject itemButton;

    PlayerInventory pi;
    // Start is called before the first frame update
    void Start()
    {
        pi = PlayerInventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            for (int i = 0; i < pi.slots.Length; i++)
            {
                if(pi.isInventoryFull[i] == false) //check to see if the iventory slot is empty
                {
                    pi.isInventoryFull[i] = true;
                    Instantiate(itemButton, pi.slots[i].transform, false); //fill inventory slot with picked object
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
