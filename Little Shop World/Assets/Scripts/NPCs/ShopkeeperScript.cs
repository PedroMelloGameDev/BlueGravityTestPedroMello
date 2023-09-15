using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperScript : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject shopKeeperScreen;
    [SerializeField] GameObject outline;

    // Start is called before the first frame update
    void Start()
    {
        shopKeeperScreen.SetActive(false);
        outline.SetActive(false);
    }

    public void Interact()
    {
        shopKeeperScreen.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            outline.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            outline.SetActive(false);
            shopKeeperScreen.SetActive(false);
        }
    }
}
