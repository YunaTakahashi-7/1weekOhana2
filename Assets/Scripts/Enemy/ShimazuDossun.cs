using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShimazuDossun : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip DossunSE;
    public GameObject shimazuD;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            StartCoroutine("DosuunSEPlay");
            Destroy(shimazuD, 2f);


        }

    }

    IEnumerator DosuunSEPlay()
    {
        yield return new WaitForSeconds(0.8f);
        audioSource.PlayOneShot(DossunSE);

    }

}
