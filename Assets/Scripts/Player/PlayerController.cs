using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip Attack1;
    public AudioClip Attack2;
    public AudioClip damage;
    public AudioClip gameover;
    public AudioClip jump;


    public static bool Reset;
    public GameObject Main;
    public GameObject Death;
    public GameObject Damage;
    public static int PlayerHp = 10;
    bool Muteki;
    [SerializeField] LayerMask blockLayer;
    [SerializeField] GameObject[] Damages; // 揺らすオブジェクト
    [SerializeField] float duration;            // 揺れる時間
    [SerializeField] float strength = 1f;       // 揺れる幅
    [SerializeField] int vibrato = 10;          // 揺れる回数
    [SerializeField] float randomness = 90f;    // Indicates how much the shake will be random (0 to 180 ...
    [SerializeField] bool snapping = false;     // If TRUE the tween will smoothly snap all values to integers. 
    [SerializeField] bool fadeOut = true;       // 徐々に揺れが収まるか否か

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

    public GameObject SceneToGame;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        PlayerHp = 10;
        Reset = false;
        sword.SetActive(false);
        Death.SetActive(false);
        Damage.SetActive(false);
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        //PlayerDeathSE();
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

        if(transform.position.y < -15.0f)
        {
            
            Reset = true;
            Death.SetActive(true);
            Main.SetActive(false);
            Destroy(this.gameObject); // gameover処理かく

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
        audioSource.PlayOneShot(jump);
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
        float random = Random.value; //0から1の値をランダムに作る
        animator.SetTrigger("Attack");
        if (random <= 0.5f)
        {
            //音鳴らす処理
            audioSource.PlayOneShot(Attack1);
        }
        else
        {
            //音鳴らす処理
            audioSource.PlayOneShot(Attack2);

        }
    }
    void Setting()
    {
        sword.SetActive(true);
        
    }
    void EndSetting()
    {
        sword.SetActive(false) ;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == true)
        {
            PlayerHp--;
            if (PlayerHp > 0)
            {
                Muteki = true;
                if (Muteki == true)
                {
                    audioSource.PlayOneShot(damage);
                    animator.SetTrigger("Damage");
                    Damage.SetActive(true);
                    Main.SetActive(false);
                    GetComponent<Collider2D>().enabled = false;
                    Shake(Damages);
                    StartCoroutine("MutekiTime");
                }
            }

            if (PlayerHp == 0)
            {
                // audioSource.PlayOneShot(gameover);
                Death.SetActive(true);
                Main.SetActive(false);
                Damage.SetActive(false);
                Reset = true;
                Destroy(this.gameObject); // gameover処理かく

                // gameover
                
                /*if (SceneToGame.activeSelf){
                    SceneManager.LoadScene ("GameScene");
                }else{
                    // SceneManager.LoadScene ("BossScene"); //倒せないから一旦オフ
                }
                */
            }
        }

    }
    IEnumerator MutekiTime()
    {
        // 1秒間処理を止める
        yield return new WaitForSeconds(1.5f);
        Damage.SetActive(false);
        Main.SetActive(true);
        GetComponent<Collider2D>().enabled = true;

        Muteki = false;

    }


    // DOTweenでオブジェクトをゆらす
    private void Shake(GameObject[] Damages)
    {
        foreach (var PlayerDamage in Damages)
        {
            PlayerDamage.transform.DOShakePosition(
                duration, strength, vibrato, randomness, snapping, fadeOut);


            // DOShakePosition は duration 以外の引数はオプション（指定しなければデフォルト値使用）
            // なので、以下のようにシンプルに書くこともできる
            // shakeObject.transform.DOShakePosition ( duration );
        }
    }


}
