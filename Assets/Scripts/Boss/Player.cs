using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float life;
    public float maxLife;
    //Bullet.csで使うフラグ
    public static bool onright;
 
    protected PlayerGauge playerGauge;

    private void OnEnable()
    {
        life = 10;
    }
 
    private void Start()
    {
        playerGauge = GameObject.FindObjectOfType<PlayerGauge>();
        playerGauge.SetPlayer(this);
        life = PlayerController.PlayerHp;
    }

    private void Update()
    {
        if(gameObject.transform.localScale.x >= 0){
            onright = true;
        }else{
            onright = false;
        }
    }
 
    public void Damage()
    {
        playerGauge.GaugeReduction(1.0f);
        // life -= 1.0f;
        life = PlayerController.PlayerHp;
        Debug.Log("life" + life);
        Debug.Log("PlayerHp,lifeのあと" + PlayerController.PlayerHp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == true)
        {
            Damage();
        }
    }
}
