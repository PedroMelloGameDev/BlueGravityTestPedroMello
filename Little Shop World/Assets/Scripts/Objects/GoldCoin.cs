using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    PlayerData pd;
    // Start is called before the first frame update
    void Start()
    {
        pd = PlayerData.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            pd.UpdateMoney(1);
            Destroy(this.gameObject);
        }
    }
}
