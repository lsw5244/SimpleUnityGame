using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControll : MonoBehaviour {

    float x, y;

    public float speed;
    public Text scoreText;

    float direction = 1f;

    int point = 0;

    bool iceHit = false;

    public GameObject explosionParticle;

    float isOneSec = 0;

    void FixedUpdate ()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed * direction;
        y = Input.GetAxis("Vertical") * Time.deltaTime * speed * direction;

        if (Input.GetMouseButton(0))
        {
            y = speed * Time.deltaTime;
        }
        else
        {
            y = speed * Time.deltaTime * -1f;
        }
        transform.position += new Vector3(x, y, 0f);

        isOneSec += Time.deltaTime;
        if(isOneSec > 0.1) //0.1초마다 3점 추가
        {
            point += 3;
            PointUp();
            isOneSec = 0;
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireBall")
        {
            GameObject exp = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(exp, 3f);

            Destroy(this.gameObject);
            Destroy(other.gameObject);

            //Application.LoadLevel(Application.loadedLevel);
            GameObject.Find("Gamemanager").GetComponent<DiePlayer>().score = point;
            GameObject.Find("Gamemanager").GetComponent<DiePlayer>().playerDie = true;
            scoreText.text = "";
        }

        if(other.gameObject.tag == "PointDown")
        {
            //direction *= -1;
            //Destroy(other.gameObject);
            point -= 150;
            PointUp();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Freeze")
        {
            StartCoroutine(StopPlayer());
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Gold")
        {
            point += 100;
            PointUp();
            Debug.Log("Point : " + point);
            Destroy(other.gameObject);
        }
    }

    void PointUp()
    {
        scoreText.text = "Score : " + point;
    }

    IEnumerator StopPlayer()
    {
        float tempx = x;
        float tempy = y;
        if(!iceHit)
        {
            iceHit = true;
            x = 0;
            y = 0;
            float temp = speed;
            speed = 0f;

            yield return new WaitForSeconds(1f); //프리징 끝
            iceHit = false;
            x = tempx;
            y = tempy;
            speed = temp;
        }
        else
        {
            yield return null;
        }
        
    }

}
