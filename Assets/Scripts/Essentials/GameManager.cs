using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public static GameManager gameManager;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if(gameManager != this)
        {
            Destroy(gameObject);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
     
       
        if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("1");
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }


}
