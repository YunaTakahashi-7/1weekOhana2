using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReload : MonoBehaviour
{
    public GameObject movie;
    public GameObject game;
    public GameObject movietimeline;

    void OnEnable ()
    {
        //二回目以降用
        int resultScore = PlayerPrefs.GetInt("SCORE");
        if(resultScore == 20)
        {
            movietimeline.SetActive(false);
            game.SetActive(true);
            Debug.Log("gameがtrue" + game.activeSelf);
            Destroy(movie);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
