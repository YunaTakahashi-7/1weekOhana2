using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    public GameObject blackA;
    public GameObject blackB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("Fall", 5);
        }
    }

    void Fall()
    {
        transform.position = new Vector3(0, -0.1f, 0);

    }


}
