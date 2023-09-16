using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{

    [SerializeField] GameObject itemImage;

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

    public void EquipItem()
    {
        for (int i = 0; i < pi.equipSlots.Length; i++)
        {
            if (pi.isEquipFull[i] == false) //check to see if the iventory slot is empty
            {
                pi.isEquipFull[i] = true;
                Instantiate(itemImage, pi.equipSlots[i].transform, false);
                pc.hatSpace.GetComponent<SpriteRenderer>().sprite = itemImage.GetComponent<Image>().sprite; //change the hat sprite to the new one
                Destroy(gameObject);
                break;
            }
        }
    }
}
