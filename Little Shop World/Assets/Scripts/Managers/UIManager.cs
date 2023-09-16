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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCoolnessFill(int coolnessFillAmount)
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
