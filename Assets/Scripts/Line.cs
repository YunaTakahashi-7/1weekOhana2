using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject Main;
    public GameObject Death;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Main.SetActive(false);
        Death.SetActive(true);
        Destroy(collision.gameObject);
    }
}
