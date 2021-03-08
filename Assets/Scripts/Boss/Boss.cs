using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float life;
    public float maxLife;
 
    protected BossGauge bossGauge;
 
    private void Start(){
        bossGauge = GameObject.FindObjectOfType<BossGauge>();
        bossGauge.SetBoss(this);
        life = Bosshp.bosshp;
    }
 
    private void Damage(){
        bossGauge.GaugeReduction(1.0f);
        life -= 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") == true)
        {
            Damage();
        }
    }
}
