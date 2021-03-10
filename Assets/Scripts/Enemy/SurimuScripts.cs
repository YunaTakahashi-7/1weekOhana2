using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurimuScripts : MonoBehaviour
{
    [SerializeField] LayerMask blockLayer;

    AudioSource audioSource;
    public AudioClip monsterDamage;

    public int EnemyHp = 3;
    public GameObject Zangeki;
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
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        direction = DIRECTION_TYPE.LEFT;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0.04f, 0);

        if (!IsGround())
        {
            ChangeDirection();
        }
        if (transform.position.y < -10.0f)
        {
            Destroy(this.gameObject); // gameover処理かく
        }

    }


    void FixedUpdate()
    {
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;
            case DIRECTION_TYPE.RIGHT:
                speed = 1;
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

        if (collision.CompareTag("Sword") == true)
        {
            audioSource.PlayOneShot(monsterDamage);
            StartCoroutine("Change");
            Instantiate(Zangeki, transform.position, transform.rotation);
            transform.position += new Vector3(0.3f, 0.3f, 0);

            EnemyHp--;
            if (EnemyHp == 0)
            {
                Destroy(this.gameObject);
                // 爆破
            }
        }

    }
    bool IsGround()
    {
        Vector3 startVec = transform.position + transform.right * 0.5f * transform.localScale.x;
        Vector3 endVec = startVec - transform.up * 5f;
        Debug.DrawLine(startVec, endVec);
        return Physics2D.Linecast(startVec, endVec, blockLayer);
    }

    void ChangeDirection()
    {
        if (direction == DIRECTION_TYPE.RIGHT)
        {
            direction = DIRECTION_TYPE.LEFT;
        }
        else if (direction == DIRECTION_TYPE.LEFT)
        {
            direction = DIRECTION_TYPE.RIGHT;
        }
    }
    IEnumerator Change()
    {
        yield return new WaitForSeconds(0.5f);
        direction = DIRECTION_TYPE.LEFT; // ダメージ受けたら左向く
    }


}
