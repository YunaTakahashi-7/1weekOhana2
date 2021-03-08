using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonbiSyutsugenn : MonoBehaviour
{

    public GameObject zonbi;

    private void Start()
    {
        zonbi.SetActive(false);

    }
    //public GameObject player;
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            zonbi.SetActive(true);
        }

    }
}
