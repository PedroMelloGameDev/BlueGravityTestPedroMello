using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDroppedItem : MonoBehaviour
{
    [SerializeField] GameObject itemToSpawn;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Spawn()
    {
        Instantiate(itemToSpawn, player.position, Quaternion.identity); 
        //instantiating the dropped object at the player position
        //if his inventory has space it will go directly to it
        //if not it stays on the ground where it can be picked up later
    }
}
