using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    List<IInteractable> interactablesInRange = new List<IInteractable>();

    PlayerInventory pi;
    AudioScript audioSource;

    // Start is called before the first frame update
    void Start()
    {
        pi = PlayerInventory.instance;
        audioSource = AudioScript.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var interactable = interactablesInRange[0];
            interactable.Interact();
            audioSource.InteractSound();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if( interactable != null)
        {
            interactablesInRange.Add(interactable);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (interactablesInRange.Contains(interactable))
        {
            interactablesInRange.Remove(interactable);
            pi.CloseInventory(); //making sure the players inventory is closed after an interaction with the shopkeeper
        }
    }
}
