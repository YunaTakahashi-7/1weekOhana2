using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleresetplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("SCORE", 0);
        PlayerPrefs.Save ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
