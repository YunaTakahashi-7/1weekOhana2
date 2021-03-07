using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshp : MonoBehaviour
{
    public int bosshp = 20;
    private int halfhp;
    public GameObject Zangeki;
    
    void Start()
    {
        halfhp = bosshp / 2;
    }

    void Update()
    {
        if(bosshp <= halfhp){
            transform.Rotate(new Vector3(0, 0, 3));
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword") == true)
        {
            Instantiate(Zangeki, transform.position, transform.rotation);
            transform.position += new Vector3(0.3f, 0.3f, 0);

            bosshp--;
        }
    }
}
