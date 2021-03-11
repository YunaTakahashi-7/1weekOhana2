using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBoss : MonoBehaviour
{
    private bool GameOverFrag = false;
    public GameObject GameOverText;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerController.PlayerHp <= 0)
        {
            if(!GameOverFrag)
            {
                GameOverText.SetActive(true);
                GameOverFrag = true;
            }
        }
        if(GameOverText.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("BossScene");
            }
        }
    }
}
