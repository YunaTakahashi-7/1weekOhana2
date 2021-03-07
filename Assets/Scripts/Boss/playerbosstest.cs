using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbosstest : MonoBehaviour
{
    public Transform attackpoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    Rigidbody2D rb;
    // Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Attack();
        // }
    }

    void Attack(){
        Debug.Log("攻撃");
        // Collision2D[] hitEnemy = Physics2D.OverlapCircleAll(attackpoint.position, attackRadius, enemyLayer);
    }

    // private void OnDrawGizumosSelected(){
    //     Gizumos.color = color.red;
    //     Gizumos.DrawWireSphere(attackpoint.position, attackRadius);
    // }
}
