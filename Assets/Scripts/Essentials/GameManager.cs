using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
    
public class GameManager : MonoBehaviour
{
    public int score = 0;

    public static GameManager gameManager;
    public GameObject pauseMenu;
    public TextMeshProUGUI scoreTxt;

    // Start is called before the first frame update
    void Start()
    {

        if(SceneManager.GetActiveScene().buildIndex==0)
        {
            scoreTxt.text = PlayerPrefs.GetInt("score").ToString();
            score = PlayerPrefs.GetInt("score");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            scoreTxt.text = score.ToString();
            PlayerPrefs.SetInt("score", score);


            if (Input.GetKey(KeyCode.P))
            {
                //Debug.Log("1");
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }
        public void resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        
    }

}
