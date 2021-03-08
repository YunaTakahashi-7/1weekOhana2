using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    private int count = 0;
    private float time = 0;

    void Start()
    {
        // StartCoroutine (MoveSet ());
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time < 2){
            transform.position += new Vector3(0, 1.1f, 0) * Time.deltaTime;
        }else if(time < 5){
            transform.position += new Vector3(0, -1.2f, 0) * Time.deltaTime;
        }else if(time < 8){
            transform.position += new Vector3(0, 1.2f, 0) * Time.deltaTime;
        }else if(time < 11){
            transform.position += new Vector3(-4.0f, -1.2f, 0) * Time.deltaTime;
        }else if(time < 14){
            transform.position += new Vector3(0, 1.2f, 0) * Time.deltaTime;
        }else if(time < 16){
            transform.position += new Vector3(0, -1.1f, 0) * Time.deltaTime;
        }else if(time < 17.5){
            transform.position += new Vector3(4.0f, -1.2f, 0) * Time.deltaTime;
        }else if(time < 19){
            transform.position += new Vector3(4.0f, 1.2f, 0) * Time.deltaTime;
        }else if(time < 21){
            transform.position += new Vector3(-6.0f, 0, 0) * Time.deltaTime;
        }else if(time < 23){
            transform.position += new Vector3(6.0f, 0, 0) * Time.deltaTime;
        }else{
            time = 0;
        }
        // if(time >= 16.5f){
        //     time = 0;
        //     StartCoroutine (MoveSet ());
        // }
    }

    // private IEnumerator MoveSet()
    // {
    //     while(count < 10){
    //         yield return new WaitForSeconds (0.2f);
    //         transform.position += new Vector3(0, 20f, 0) * Time.deltaTime;
    //         count++;
    //     }
    //     while(count < 30){
    //         yield return new WaitForSeconds (0.2f);
    //         transform.position += new Vector3(0, -20f, 0) * Time.deltaTime;
    //         count++;
    //     }
    //     while(count < 50){
    //         yield return new WaitForSeconds (0.2f);
    //         transform.position += new Vector3(0, 20f, 0) * Time.deltaTime;
    //         count++;
    //     }
    //     yield return new WaitForSeconds (1f);
    //     while(count < 75){
    //         yield return new WaitForSeconds (0.1f);
    //         transform.position += new Vector3(-60f, -20f, 0) * Time.deltaTime;
    //         count++;
    //     }
    //     while(count < 95){
    //         yield return new WaitForSeconds (0.1f);
    //         transform.position += new Vector3(60f, 20f, 0) * Time.deltaTime;
    //         count++;
    //     }
    //     // Debug.Log(time);
    //     count = 0;
    // }

    // private float time = 0;
    // private bool uemove = true;
    
    // void Start()
    // {
    //     // StartCoroutine ("Move", 3);
    // }

    // void Update()
    // {
    //     time = Time.deltaTime;
    //     normalmove();
    // }

    // private void shitamove(){
    //     for(int i = 0; i < 10; i++)
    //     transform.position -= new Vector3(0.01f, 0, 0);
    // }

    // private void normalmove(){
    //     Transform myTransform = this.transform;
    //     if(uemove){
    //         transform.position += new Vector3(0, 0.01f, 0);
    //     }else{
    //         transform.position -= new Vector3(0, 0.01f, 0);
    //     }
    // }

    // void OnTriggerStay2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "RZone")
    //     {
    //         if(uemove){
    //             uemove = false;
    //         }else{
    //             uemove = true;
    //         }
    //     }
    // }
}