using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBoss : MonoBehaviour
{
    private bool GameOverFrag = false;
    public GameObject GameOverText;

    AudioSource audioSource;
    public AudioClip bbbbb;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(PlayerController.PlayerHp <= 0)
        {
            if(!GameOverFrag)
            {
                audioSource.PlayOneShot(bbbbb);
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
