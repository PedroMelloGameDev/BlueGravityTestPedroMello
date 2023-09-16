using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1Script : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject NPCLines;
    [SerializeField] GameObject outline;


    // Start is called before the first frame update
    void Start()
    {
        AllScreensFalse();
    }

    public void Interact()
    {
        StartInteraction();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            outline.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AllScreensFalse();
        }
    }
    void AllScreensFalse()
    {
        NPCLines.SetActive(false);
        outline.SetActive(false);
    }
    void StartInteraction()
    {
        outline.SetActive(true);
        NPCLines.SetActive(true);
    }
}
