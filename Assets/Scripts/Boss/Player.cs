using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float life;
    public float maxLife;
 
    protected PlayerGauge playerGauge;
 
    private void Start()
    {
        playerGauge = GameObject.FindObjectOfType<PlayerGauge>();
        playerGauge.SetPlayer(this);
        life = PlayerController.PlayerHp;
    }
 
    public void Damage()
    {
        playerGauge.GaugeReduction(1.0f);
        life -= 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == true)
        {
            Damage();
        }

    }
}
