using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private bool goright = true;

    void OnEnable(){
        if(Player.onright){
            goright = true;
        }else{
            goright = false;
        }
    }

    void Update()
    {
        if(goright){
            transform.position += transform.right * 10 * Time.deltaTime ;
        }else{
            transform.position -= transform.right * 10 * Time.deltaTime ;
        }
        //右方向に移動
        // transform.position += transform.right * 10 * Time.deltaTime ;
    }

    private void OnBecameInvisible()
    {
        //画面外に行ったら非アクティブにする
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("RZone") == true){
            gameObject.SetActive(false);
        }
    }
}
