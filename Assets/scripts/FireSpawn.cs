using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawn : MonoBehaviour {

    [HideInInspector]
    public bool playerDie = false;
    public GameObject fire;
    public float spawnTime = 0.4f;

    Vector3 newspawn;
    void Start()
    {
        StartCoroutine(SpSt());
        StartCoroutine(LessenSpwanTime());
    }

    private void Update()
    {
        Debug.Log(spawnTime + "");
       
    }

    IEnumerator LessenSpwanTime()
    {
        while(spawnTime >= 0.1f)
        {
            if (playerDie)
                break;
            yield return new WaitForSeconds(3);
            spawnTime -= 0.02f;
            GameObject.Find("Gamemanager").GetComponent<ItemSpawn>().spawnTime = spawnTime * 2;
        }
    }

    IEnumerator SpSt()
    {
        while (!playerDie)
        {
            yield return new WaitForSeconds(spawnTime);
            newspawn = new Vector3(Random.Range(13f, 17f), Random.Range(-4f, 6f), 0f);
            Instantiate(fire, newspawn, fire.transform.rotation);
        }
    }
}