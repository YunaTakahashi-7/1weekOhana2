using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject ending;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.enabled = false;
        StartCoroutine("AudioOn");
    }
    public void Update()
    {
        if(ending.activeSelf)
        {
            audioSource.enabled = false;
        }
    }

    IEnumerator AudioOn()
    {
        yield return new WaitForSeconds(5f);
        audioSource.enabled = true;
    }

    
}
