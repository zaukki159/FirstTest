using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerHealth : MonoBehaviour
{


    public float Health = 100;
    public Image healthBar;
    public GameObject deathMenu;
    public GameManager gameManager;

    public void damage(float damage)
    {
        Health -= damage;
        healthBar.fillAmount = Health/100;
        if(Health<=0)
        {
            if(gameManager.score>PlayerPrefs.GetInt("score"))
            {
                PlayerPrefs.GetInt("score", gameManager.score);
            }
            deathMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
