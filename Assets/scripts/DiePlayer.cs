using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiePlayer : MonoBehaviour {

    public Text gameOverText;
    public Text scoreText;
    public Button retryBtn;
    public Button backBtn;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public bool playerDie = false;

	void Start () {
        StartCoroutine(Die());	
	}

	IEnumerator Die()
    {
        while(true)
        {
            if(playerDie)
            {
                gameOverText.text = "GameOver";
                scoreText.text = "Your Score : " + score;
                retryBtn.gameObject.SetActive(true);
                backBtn.gameObject.SetActive(true);
                GetComponent<FireSpawn>().playerDie = true;
                GetComponent<ItemSpawn>().playerDie = true;
                GetComponent<StarSpawn>().playerDie = true;
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }
}
