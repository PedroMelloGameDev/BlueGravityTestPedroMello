using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{

    UIManager ui;
    PlayerData pd;
    AudioScript audioSource;
    // Start is called before the first frame update
    void Start()
    {
        ui = UIManager.instance;
        pd = PlayerData.instance;
        audioSource = AudioScript.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            pd.money += 1;
            audioSource.CoinSound();
            ui.UpdateMoney(pd.money);
            Destroy(this.gameObject);
        }
    }
}
