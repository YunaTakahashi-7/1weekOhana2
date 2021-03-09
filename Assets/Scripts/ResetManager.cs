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

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Reset)
        {
            audioSource.PlayOneShot(gameover);
            gameOverText.SetActive(true);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("GameScene");

            }
        }
    }
}
