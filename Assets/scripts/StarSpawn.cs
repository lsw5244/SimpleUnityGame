using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour {

    [HideInInspector]
    public bool playerDie = false;

    public GameObject star;
    public float spawnTime = 0.2f;

    Vector3 newpawn;
    void Start()
    {
        StartCoroutine(SpSt());
    }

    IEnumerator SpSt()
    {
        while (!playerDie)
        {
            yield return new WaitForSeconds(spawnTime);
            newpawn = new Vector3(Random.Range(13f, 17f), Random.Range(-4f, 6f), Random.Range(-1f, 3f));
            Instantiate(star, newpawn, Quaternion.identity);
        }
    }
}
// Random.Range(13f, 17f), Random.Range(-4f, 6f), Random.Range(-1f, 3f)

/*Vector3 newpawn = new Vector3(Random.Range(13f, 17f), Random.Range(-4f, 6f), Random.Range(-1f, 3f));
nextSpawn = Time.time + 0.1f;
            Instantiate(star, newpawn, Quaternion.identity); */
