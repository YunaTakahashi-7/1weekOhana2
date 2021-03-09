using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetManager : MonoBehaviour
{
    public GameObject gameOverText;
    AudioSource audioSource;
    public AudioClip gameover;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverText.SetActive(false);
    }

    void Update()
    {
        if (PlayerController.Reset)
        {
            AudioSource.PlayClipAtPoint(gameover, transform.position);
            gameOverText.SetActive(true);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("GameScene");

            }
        }
    }
}
