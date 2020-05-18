using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovePlayer : MonoBehaviour {

    float x, y;

    public float speed;
    public Text scoreText;

    float direction = 1f;

    int point = 0;

    bool iceHit = false;



    void FixedUpdate ()
    {
        //x = Input.GetAxis("Horizontal") * Time.deltaTime * speed * direction;
        //y = Input.GetAxis("Vertical") * Time.deltaTime * speed * direction;
        transform.position += new Vector3(x, y, 0f);

	}

    public void MoveUpBtn()
    {
        if(!iceHit)
        {
            x = 0;
            y = 1f * Time.deltaTime * speed * direction;
        }
    }

    public void MoveDownBtn()
    {
        if(!iceHit)
        {
            x = 0;
            y = -1f * Time.deltaTime * speed * direction;

        }
    }

    public void MoveLeftBtn()
    {
        if(!iceHit)
        {
            y = 0;
            x = -1f * Time.deltaTime * speed * direction;
        }
    }

    public void MoveRightBtn()
    {
        if(!iceHit)
        {
            y = 0;
            x = 1f * Time.deltaTime * speed * direction;
        }
    }

    public void MoveStopBtn()
    {
        if(!iceHit)
        {
            x = 0;
            y = 0;
        }
    }

    public void MoveUpLeftBtn()
    {
        if (!iceHit)
        {
            x = -1 * Time.deltaTime * speed * direction;
            y = 1 * Time.deltaTime * speed * direction;
        }
    }

    public void MoveUpRightBtn()
    {
        if (!iceHit)
        {
            x = 1 * Time.deltaTime * speed * direction;
            y = 1 * Time.deltaTime * speed * direction;
        }
    }

    public void MoveDownLeftBtn()
    {
        if (!iceHit)
        {
            x = -1 * Time.deltaTime * speed * direction;
            y = -1 * Time.deltaTime * speed * direction;
        }
    }

    public void MoveDownRightBtn()
    {
        if (!iceHit)
        {
            x = 1 * Time.deltaTime * speed * direction;
            y = -1 * Time.deltaTime * speed * direction;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireBall")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            //Application.LoadLevel(Application.loadedLevel);
            GameObject.Find("Gamemanager").GetComponent<DiePlayer>().score = point;
            GameObject.Find("Gamemanager").GetComponent<DiePlayer>().playerDie = true;
            scoreText.text = "";
            
            //SceneManager.LoadScene("MYC", LoadSceneMode.Single);
        }

        if(other.gameObject.tag == "Changer")
        {
            direction *= -1;
           // Invoke("ResetDirection", 3f);
            Destroy(other.gameObject);
            //GameObject.Find("Gamemanager").GetComponent<TextControl>()

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
            yield return new WaitForSeconds(1f);
            iceHit = false;
            x = tempx;
            y = tempy;
        }
        else
        {
            yield return null;
        }
        
    }

}
