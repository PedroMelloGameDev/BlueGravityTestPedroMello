using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEquipSlot : MonoBehaviour
{
    [SerializeField] GameObject itemButton;

    PlayerInventory pi;
    PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        pi = PlayerInventory.instance;
        pc = PlayerController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void ClearEquipItem()
    {
        for (int i = 0; i < pi.slots.Length; i++)
        {
            if (pi.isInventoryFull[i] == false) //check to see if the iventory slot is empty
            {
                pi.isInventoryFull[i] = true;
                Instantiate(itemButton, pi.slots[i].transform, false);
                pc.hatSpace.GetComponent<SpriteRenderer>().sprite = null;
                Destroy(gameObject);
                break;
            }
        }
    }*/
}
