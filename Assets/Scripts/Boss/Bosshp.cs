using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshp : MonoBehaviour
{
    public int bosshp = 20;
    private int halfhp;
    public GameObject Zangeki;
    private SpriteRenderer renderer;　//点滅用
    private bool on_damage = false;
    
    void Start()
    {
        halfhp = bosshp / 2;
        renderer = gameObject.GetComponent<SpriteRenderer>(); //点滅用
    }

    void Update()
    {
        if(bosshp == 0){
            Debug.Log("しまづさんを倒した");
            //爆発エフェクト入れる
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
}
