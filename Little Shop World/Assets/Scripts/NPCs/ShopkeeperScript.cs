using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperScript : MonoBehaviour, IInteractable
{
    [Header("Shopkeeper GameObjects")]
    [SerializeField] GameObject shopKeeperScreen;
    [SerializeField] GameObject outline;
    [SerializeField] GameObject buyAndSellButtons;
    [SerializeField] GameObject itensToSell;
    [SerializeField] GameObject notEnoughtMoneyImage;
    [SerializeField] GameObject coolestHatInfo;

    [SerializeField] GameObject playerInventorySlot1;
    [SerializeField] GameObject playerInventorySlot2;
    [SerializeField] GameObject playerInventorySlot3;

    PlayerInventory pi;
    PlayerData pd;

    // Start is called before the first frame update
    void Start()
    {
        AllScreensFalse();
        pi = PlayerInventory.instance;
        pd = PlayerData.instance;
    }

    public void Interact()
    {
        StartInteraction();
        pi.OpenInventory();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            outline.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AllScreensFalse();
        }
    }

    public void BuyPlayerHat()
    {
        for (int i = 0; i < pi.slots.Length; i++)
        {
            if (pi.isInventoryFull[i] == true) //check to see if the iventory slot is empty
            {
                pi.isInventoryFull[i] = false;
                Destroy(pi.slots[i].transform.GetChild(i).gameObject);
                pd.UpdateMoney(5);
                break;
            }
        }
    }

    #region Shopkeeper Screen states
    void AllScreensFalse() //set all Shopkeeper game objects to false
    {
        shopKeeperScreen.SetActive(false);
        outline.SetActive(false);
        buyAndSellButtons.SetActive(false);
        itensToSell.SetActive(false);
        notEnoughtMoneyImage.SetActive(false);
        coolestHatInfo.SetActive(false);
    }
    public void StartInteraction() //first game objects to become visible in the beginning of the interaction
    {
        outline.SetActive(true);
        shopKeeperScreen.SetActive(true);
        buyAndSellButtons.SetActive(true);
        itensToSell.SetActive(false);
        coolestHatInfo.SetActive(false);
    }
    public void BuyItensScreen() //screen where the player can buy the hats
    {
        outline.SetActive(true);
        shopKeeperScreen.SetActive(true);
        buyAndSellButtons.SetActive(false);
        itensToSell.SetActive(true);
        coolestHatInfo.SetActive(false);
    }
    public void CoolestHatInformation() //screen about the coolest hat and how to get it
    {
        outline.SetActive(true);
        shopKeeperScreen.SetActive(true);
        buyAndSellButtons.SetActive(false);
        itensToSell.SetActive(false);
        coolestHatInfo.SetActive(true);
    }
    #endregion
}
