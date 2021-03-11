using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene ("TitleScene");
    }

    void Update()
    {
        
    }

    public void SceneToTitle()
    {
        SceneManager.LoadScene ("TitleScene");
    }
}
