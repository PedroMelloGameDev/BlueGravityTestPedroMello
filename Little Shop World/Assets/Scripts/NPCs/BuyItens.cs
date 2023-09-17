using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItens : MonoBehaviour
{
    [SerializeField] int itemPrice;
    [SerializeField] GameObject notEnoughtMoneyImage;
    [SerializeField] GameObject itemToInstantiate;

    Transform player;


    UIManager ui;
    PlayerData pd;
    // Start is called before the first frame update
    void Start()
    {
        notEnoughtMoneyImage.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        ui = UIManager.instance;
        pd = PlayerData.instance;
    }

    public void PurchuseItem()
    {
        if(pd.money < itemPrice) //checking to see if the player can afford to buy the item
        {
            notEnoughtMoneyImage.SetActive(true);
        }
        else if(pd.money >= itemPrice)
        {
            pd.money -= itemPrice;
            ui.UpdateMoney(pd.money);
            notEnoughtMoneyImage.SetActive(false);
            Instantiate(itemToInstantiate, player.position, Quaternion.identity);
            //instantiating the item in the player position
            //if the inventory is full the item stays on the ground where he can pick it up later
        }
    }
}
