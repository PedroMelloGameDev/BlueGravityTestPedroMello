using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipItensUI : MonoBehaviour
{
    public static PlayerEquipItensUI instance;

    [Header("Player Equipaple Parts")]
    [SerializeField] GameObject head;

    [SerializeField] GameObject playerInventory;
    bool inventoryOpen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenCloseIventory();
        }
    }

    public void OpenCloseIventory()
    {
        if (!inventoryOpen)
        {
            playerInventory.SetActive(true);
            inventoryOpen = true;
        }

        else if (inventoryOpen)
        {
            playerInventory.SetActive(false);
            inventoryOpen = false;
        }
    }
}
