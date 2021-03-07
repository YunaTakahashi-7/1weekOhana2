using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enum DIRECTION_TYPE
    {
        STOP,
        LEFT,
        RIGHT,
    }
    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;
    float speed;
    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        direction = DIRECTION_TYPE.LEFT;
    }
    void FixedUpdate()
    {
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;
            case DIRECTION_TYPE.RIGHT:
                speed = 3;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case DIRECTION_TYPE.LEFT:
                speed = -1;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damager damager = collision.GetComponent<Damager>();
        if(damager != null)
        {
            Debug.Log("aaaa");
        }
    }

}
