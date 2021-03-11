using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image> ().enabled = true; //オフにしていたPanelのImageコンポーネントをオンに変更
		GetComponent<Image> ().color = new Color (255, 0, 0, 0.5f);　
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
