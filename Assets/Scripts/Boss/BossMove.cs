using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    private float time = 0;
    private bool uemove = true;
    
    void Start()
    {
        // StartCoroutine ("Move", 3);
    }

    void Update()
    {
        time = Time.deltaTime;
        normalmove();
    }

    private void shitamove(){
        for(int i = 0; i < 10; i++)
        transform.position -= new Vector3(0.01f, 0, 0);
    }

    private void normalmove(){
        Transform myTransform = this.transform;
        if(uemove){
            transform.position += new Vector3(0, 0.01f, 0);
        }else{
            transform.position -= new Vector3(0, 0.01f, 0);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RZone")
        {
            if(uemove){
                uemove = false;
            }else{
                uemove = true;
            }
        }
    }
}