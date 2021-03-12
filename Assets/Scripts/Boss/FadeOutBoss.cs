using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutBoss : MonoBehaviour
{
    float fadeSpeed = 0.02f;        //透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理
    private bool isFadeOut = true;
    Image fadeImage;

    void Start()
    {
        // GetComponent<Image> ().enabled = true; //オフにしていたPanelのImageコンポーネントをオンに変更
		// GetComponent<Image> ().color = new Color (255, 0, 0, 0.5f);　
        fadeImage = GetComponent<Image> ();
        red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bosshp.bosshp <= 0 && isFadeOut) {
			StartFadeOut ();
		}
    }

    void StartFadeOut(){
		fadeImage.enabled = true;  // a)パネルの表示をオンにする
		alfa += fadeSpeed;         // b)不透明度を徐々にあげる
		SetAlpha ();               // c)変更した透明度をパネルに反映する
		if(alfa >= 1){             // d)完全に不透明になったら処理を抜ける
			isFadeOut = false;
		}
	}

    void SetAlpha(){
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}
