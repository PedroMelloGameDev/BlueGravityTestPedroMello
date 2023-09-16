using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperScript : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject shopKeeperScreen;
    [SerializeField] GameObject outline;
    [SerializeField] GameObject buyAndSellButtons;
    [SerializeField] GameObject itensToSell;
    [SerializeField] GameObject notEnoughtMoneyImage;

    // Start is called before the first frame update
    void Start()
    {
        AllScreensFalse();
    }

    public void Interact()
    {
        StartInteraction();
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
    void AllScreensFalse()
    {
        shopKeeperScreen.SetActive(false);
        outline.SetActive(false);
        buyAndSellButtons.SetActive(false);
        itensToSell.SetActive(false);
        notEnoughtMoneyImage.SetActive(false);
    }
    void StartInteraction()
    {
        outline.SetActive(true);
        shopKeeperScreen.SetActive(true);
        buyAndSellButtons.SetActive(true);
        itensToSell.SetActive(false);
    }
    public void BuyItensScreen()
    {
        outline.SetActive(true);
        shopKeeperScreen.SetActive(true);
        buyAndSellButtons.SetActive(false);
        itensToSell.SetActive(true);
    }

}
