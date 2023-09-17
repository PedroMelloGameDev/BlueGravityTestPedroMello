using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{

    [SerializeField] GameObject itemImage;

    [Header("Coolness and Hat Settings")]
    [SerializeField] int coolnessAmount;
    [SerializeField] bool isCoolestHat;
    [SerializeField] bool isMagicianHat;


    PlayerInventory pi;
    PlayerController pc;
    PlayerData pd;
    UIManager ui;
    GameManager gm;
    AudioScript audioSource;

    // Start is called before the first frame update
    void Start()
    {
        pi = PlayerInventory.instance;
        pc = PlayerController.instance;
        pd = PlayerData.instance;
        ui = UIManager.instance;
        gm = GameManager.instance;
        audioSource = AudioScript.instance;
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
                pd.UpdatePlayerCoolness(coolnessAmount);

                if (isMagicianHat)
                {
                    gm.OpenPath();
                }

                if (isCoolestHat)
                {
                    ui.Win();
                    audioSource.VictorySound();
                    gm.PauseAndResume();
                }
                Destroy(gameObject);
                break;
            }
        }
    }
}
