using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlot : MonoBehaviour
{
    [SerializeField] int i;

    PlayerInventory pi;
    PlayerController pc;
    UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        pi = PlayerInventory.instance;
        pc = PlayerController.instance;
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

    public void ClearSlot()
    {
        pc.hatSpace.GetComponent<SpriteRenderer>().sprite = null;
        foreach (Transform child in transform)
        {
            child.GetComponent<SpawnDroppedItem>().Spawn();
            GameObject.Destroy(child.gameObject);
            ui.UpdateCoolnessFill(0);
        }
    }
}
