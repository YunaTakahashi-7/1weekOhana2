using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] LayerMask blockLayer;
    public enum DIRECTION_TYPE
    {
        STOP,
        LEFT,
        RIGHT,
    }
    DIRECTION_TYPE directin = DIRECTION_TYPE.STOP;
    Rigidbody2D Rigidbody2D;
    float speed;
    float jumpPower = 250;
    public GameObject sword;

    Animator animator;

    private void Start()
    {
        sword.SetActive(false);
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(x));

        if(x == 0)
        {
            directin = DIRECTION_TYPE.STOP;
        }
        else if(x > 0)
        {
            directin = DIRECTION_TYPE.RIGHT;
        }
        else if(x < 0)
        {
            directin = DIRECTION_TYPE.LEFT;
        }

        if(IsGround() && Input.GetKeyDown("space"))
        {
            Jump();
        }

        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void FixedUpdate()
    {
        switch(directin)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;
            case DIRECTION_TYPE.RIGHT:
                speed = 3;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case DIRECTION_TYPE.LEFT:
                speed = -3;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        Rigidbody2D.velocity = new Vector2(speed, Rigidbody2D.velocity.y);
    }

    void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpPower);
        animator.SetTrigger("Jump");

    }

    bool IsGround()
    {
        //始点と終点を作成
        Vector3 leftStartPoint = transform.position - Vector3.right * 0.2f;
        Vector3 rightStartPoint = transform.position + Vector3.right * 0.2f;
        Vector3 endPoint = transform.position - Vector3.up * 0.1f;
        Debug.DrawLine(leftStartPoint, endPoint);
        Debug.DrawLine(rightStartPoint, endPoint);
        return Physics2D.Linecast(leftStartPoint,endPoint,blockLayer)
            || Physics2D.Linecast(rightStartPoint, endPoint, blockLayer);
    }


    void Attack()
    {
        sword.SetActive(true);
        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damager damager = collision.GetComponent<Damager>();
        if (damager != null)
        {
            animator.SetTrigger("Damage");
            Debug.Log("cccc");
        }
    }
}
