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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Instantiate(itemToSpawn, player.position, Quaternion.identity);
    }
}
