using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] TextMeshProUGUI money;
    [SerializeField] Image coolnessFill;
    [SerializeField] GameObject victoryScreen;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateCoolnessFill(0);
        victoryScreen.SetActive(false);
    }

    public void UpdateCoolnessFill(int coolnessFillAmount) //amount of coolness that the player has at the moment, determined by what hat he is wearing
    {
        coolnessFill.fillAmount = coolnessFillAmount / 100.0f;
    }
    public void UpdateMoney(int Money)
    {
        money.text = Money.ToString();
    }
    public void Win()
    {
        victoryScreen.SetActive(true);
    }
}
