using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshp : MonoBehaviour
{
    public int bosshp = 2;
    private int halfhp;
    
    void Start()
    {
        halfhp = bosshp / 2;
    }

    void Update()
    {
        if(bosshp <= halfhp){
            transform.Rotate(new Vector3(0, 0, 3));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("ぶつかった");
        if (col.gameObject.name == "Player")
        {
            Debug.Log("ppp");
            bosshp--;
        }
    }
}
