using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Script goes on the image of the object but function gets called by slot's dropItem function
    public GameObject item;
    private Transform player;
    private Transform spawner;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawner = GameObject.Find("FrontOfPlayerSpawn").transform;
    }


    public void spawnDroppedItem()
    {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z + 3);
        Vector3 spawnerPos = new Vector3(spawner.position.x, spawner.position.y, spawner.position.z);
        Instantiate(item, spawnerPos, Quaternion.identity);
    }
}
