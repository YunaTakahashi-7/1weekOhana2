using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManger : MonoBehaviour
{
    public GameObject shimazuD;

    private void Start()
    {
        shimazuD.SetActive(false);

    }
    //public GameObject player;
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            shimazuD.SetActive(true);


        }

    }

}
