using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CheckTimelineEnd : MonoBehaviour
{
    private PlayableDirector playableDirector;
	//　終了を検知したかどうか
	private bool isEnd;
    public GameObject movie;
    public GameObject game;
 
	// Use this for initialization
	void Start () {
        // //二回目以降用
        // int resultScore = PlayerPrefs.GetInt("SCORE");
        // if(resultScore == 20)
        // {
        //     game.SetActive(true);
        //     Debug.Log("gameがtrue" + game.activeSelf);
        //     Destroy(movie);
        // }

		playableDirector = GetComponent<PlayableDirector> ();
		isEnd = false;
	}
	
	// Update is called once per frame
	void Update () {
		//　タイムラインが終了したら次のシーンを読み込む
		if (!isEnd && playableDirector.state != PlayState.Playing) {
			isEnd = true;
            PlayerPrefs.SetInt("SCORE", 20);
            PlayerPrefs.Save();
            game.SetActive(true);
            movie.SetActive(false);
			// Destroy(movie);
		}
	}
}
