using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine ("Move");
    }

    void Update()
    {
        normalmove();
    }

    private IEnumerator Move() 
    { 
    Debug.Log ("1");
    shitamove();

    yield return new WaitForSeconds (0.2f); //待つ
    Debug.Log ("2");
    shitamove();

    yield return new WaitForSeconds (0.2f); //待つ
    shitamove(); 
    Debug.Log ("3");

    yield return new WaitForSeconds (0.2f); //待つ
    shitamove();
    }

    private void shitamove(){
        Transform myTransform = this.transform;
        myTransform.Translate (-0.2f, -0.2f, 0);
    }

    private void normalmove(){
        Transform myTransform = this.transform;
        myTransform.Translate (0, 0.01f, 0);
    }

    void OnCollisionStay2D(Collider2D col)
    {
        Debug.Log("ぶつかった");
        if (col.gameObject.tag == "RZone")
        {
            Debug.Log("ppp");
        }
    }
}
