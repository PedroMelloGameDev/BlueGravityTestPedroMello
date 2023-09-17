using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;


    [SerializeField] public int money;
    [SerializeField] public int playerCoolness;


    UIManager ui;
    AudioScript audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        ui = UIManager.instance;
        audioSource = AudioScript.instance;

        ui.UpdateMoney(money);
    }
    public void UpdateMoney(int amount)
    {
        money += amount;
        audioSource.CoinSound();
        ui.UpdateMoney(money);
    }
    public void UpdatePlayerCoolness(int coolness)
    {
        playerCoolness = coolness;
    }
}
