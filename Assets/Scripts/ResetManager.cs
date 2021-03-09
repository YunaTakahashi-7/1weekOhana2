using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetManager : MonoBehaviour
{
    public GameObject gameOverText;
    AudioSource audioSource;
    public AudioClip bbbbb;
    bool isGameOver;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverText.SetActive(false);
        isGameOver = false;
    }

    void Update()
    {

        if (PlayerController.Reset && isGameOver == false)
        {
            audioSource.PlayOneShot(bbbbb);
            isGameOver = true;
            gameOverText.SetActive(true);
            

            
        }
        if (Input.GetKeyDown(KeyCode.Space)&& isGameOver == true)
        {
            SceneManager.LoadScene("GameScene");

        }
    }
    
}
