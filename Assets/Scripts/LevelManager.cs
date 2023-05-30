using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float transitionTime = 1f;
    public PauseScript pause;
    public Animator fadeScreen;

    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponent<PauseScript>();
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevel(int levelNumber)
    {
        //pause.paused = false;
        //fadeScreen.SetTrigger("ChangeLevel");
        Time.timeScale = 1;
        SceneManager.LoadScene(levelNumber);
    }

    public IEnumerator NewLevel(int levelNumber)
    {
        yield return new WaitForSeconds(transitionTime);
      
    }

    public void exitApplication()
    {
        Application.Quit();
    }
}
