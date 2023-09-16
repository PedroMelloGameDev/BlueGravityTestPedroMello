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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PurchuseItem()
    {
        if(pd.money < itemPrice)
        {
            notEnoughtMoneyImage.SetActive(true);
        }
        else if(pd.money >= itemPrice)
        {
            pd.money -= itemPrice;
            ui.UpdateMoney(pd.money);
            notEnoughtMoneyImage.SetActive(false);
            Instantiate(itemToInstantiate, player.position, Quaternion.identity);
        }
    }
}
