using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlot : MonoBehaviour
{
    [SerializeField] int i;

    PlayerInventory pi;
    PlayerController pc;
    PlayerData pd;
    UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        pi = PlayerInventory.instance;
        pc = PlayerController.instance;
        pd = PlayerData.instance;
        ui = UIManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            pi.isEquipFull[i] = false;
        }
    }

    public void ClearSlot() //clearing the equip slot so the player can equip a new hat
    {
        pc.hatSpace.GetComponent<SpriteRenderer>().sprite = null;
        foreach (Transform child in transform)
        {
            child.GetComponent<SpawnDroppedItem>().Spawn(); //instantiating the hat so it can go back to the players inventory if he has space, if not, the hats "drops"
            GameObject.Destroy(child.gameObject);
            ui.UpdateCoolnessFill(0);
            pd.UpdatePlayerCoolness(0);
        }
    }
}
