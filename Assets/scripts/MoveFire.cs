using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFire : MonoBehaviour {

    public float minSpeed = 9f;
    public float maxSpeed = 13f;

    float speed;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed); //9~14
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        transform.Translate(new Vector3(0, -1 * Time.deltaTime * speed, 0));
    }
}

