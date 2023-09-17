using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour, IInteractable
{
    [SerializeField] int coolnessThreshold; //amount of coolness the player must have to interact with he object
    [SerializeField] GameObject notCoolEnough;

    [SerializeField] GameObject outline;

    [SerializeField] GameObject objectToInstantiate;
    [SerializeField] Transform instantiatePosition;

    bool hasOpened;


    PlayerData pd;
    // Start is called before the first frame update
    void Start()
    {
        pd = PlayerData.instance;

        AllGameObjectsFalse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        if(pd.playerCoolness < coolnessThreshold)
        {
            notCoolEnough.SetActive(true);
        }
        else if (pd.playerCoolness >= coolnessThreshold)
        {
            if(!hasOpened)
            {
                Instantiate(objectToInstantiate, instantiatePosition.position, Quaternion.identity);
                hasOpened = true;
            }
        }
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
            AllGameObjectsFalse();
        }
    }
    void AllGameObjectsFalse()
    {
        outline.SetActive(false);
        notCoolEnough.SetActive(false);
    }
}
