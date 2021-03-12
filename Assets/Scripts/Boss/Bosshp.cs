using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosshp : MonoBehaviour
{
    public static int bosshp = 20;
    private int halfhp;
    public GameObject Zangeki;
    private SpriteRenderer renderer;　//点滅用
    private bool on_damage = false; //無敵タイム用

    public GameObject Expro; //爆破エフェクト
    private bool bakuha = true;
    AudioSource audioSource;

    public GameObject movie;
    public GameObject ending;
    
    void Start()
    {
        //movie.SetActive(false);
        halfhp = bosshp / 2;
        renderer = gameObject.GetComponent<SpriteRenderer>(); //点滅用
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(bosshp == 0){
            //爆発エフェクト
            if(bakuha){
                Instantiate(Expro, transform.position, transform.rotation);
                Debug.Log("しまづさんを倒した");
                StartCoroutine("WaitDeath");
                bakuha = false;
            }
        }
        else if(bosshp <= halfhp){
            transform.Rotate(new Vector3(0, 0, 3));
        }
        // ダメージフラグがtrueで有れば点滅
        if(on_damage){
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            renderer.color = new Color(1f,1f,1f,level);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword") == true)
        {
            Instantiate(Zangeki, transform.position, transform.rotation);
            // transform.position += new Vector3(0.1f, 0.1f, 0);
            bosshp--;
        }else if (collision.CompareTag("Bullet") == true && !on_damage)
        {
            // Instantiate(Zangeki, transform.position, transform.rotation);
            // transform.position += new Vector3(0.1f, 0.1f, 0);
            bosshp--;
            on_damage = true;
            StartCoroutine("WaitForIt");
        }
    }

    IEnumerator WaitForIt()
    {
        // 1秒間処理を止める
        yield return new WaitForSeconds(1);

        // １秒後ダメージフラグをfalseにして点滅を戻す
        on_damage = false;
        renderer.color = new Color(1f,1f,1f,1f);
    }

    IEnumerator WaitDeath()
    {
        Expro.SetActive(true);
        audioSource.enabled = true;
        yield return new WaitForSeconds(2);
        ending.SetActive(true);
        // gameObject.SetActive(false);
    }
}
