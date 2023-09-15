using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    [Header("Player Equipaple Parts")]
    [SerializeField] GameObject head;
    public bool[] isEquipFull;
    public GameObject[] equipSlots;

    [SerializeField] GameObject playerInventory;
    bool inventoryOpen;
    public bool[] isInventoryFull;
    public GameObject[] slots;

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
            if(!inventoryOpen)
            {
                OpenInventory();
            }
            else if(inventoryOpen)
            {
                CloseInventory();
            }
        }
    }

    public void OpenInventory()
    {
        if (!inventoryOpen)
        {
            playerInventory.SetActive(true);
            inventoryOpen = true;
        }
    }
    public void CloseInventory()
    {
        if (inventoryOpen)
        {
            playerInventory.SetActive(false);
            inventoryOpen = false;
        }
    }
}
