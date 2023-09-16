using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{

    [SerializeField] GameObject itemImage;

    [SerializeField] int coolnessAmount;
    [SerializeField] bool isCoolestHat;

    [SerializeField] bool isMagicianHat;


    PlayerInventory pi;
    PlayerController pc;
    UIManager ui;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        pi = PlayerInventory.instance;
        pc = PlayerController.instance;
        ui = UIManager.instance;
        gm = GameManager.instance;
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
                ui.UpdateCoolnessFill(coolnessAmount);
                if (isMagicianHat)
                {
                    gm.OpenPath();
                }
                if (isCoolestHat)
                {
                    ui.Win();
                    gm.PauseAndResume();
                }
                Destroy(gameObject);
                break;
            }
        }
    }
}
