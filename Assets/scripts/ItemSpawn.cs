using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

    public GameObject[] items;
    public float spawnTime = 0.8f;

    [HideInInspector]
    public bool playerDie = false;

    Vector3 spawnPoint;

    void Start ()
    {
        StartCoroutine(SpawnItem());
	}

    IEnumerator SpawnItem()
    {
        while(!playerDie)
        {
            int idx = Random.Range(0, items.Length);
            spawnPoint = new Vector3(Random.Range(13f, 17f), Random.Range(-4f, 6f), 0);
            Instantiate(items[idx], spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
	
	
}
