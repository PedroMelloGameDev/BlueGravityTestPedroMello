using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{

    UIManager ui;
    PlayerData pd;
    // Start is called before the first frame update
    void Start()
    {
        ui = UIManager.instance;
        pd = PlayerData.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            pd.money += 1;
            ui.UpdateMoney(pd.money);
            Destroy(this.gameObject);
        }
    }
}
