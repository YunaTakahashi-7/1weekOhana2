using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.enabled = false;
        StartCoroutine("AudioOn");
    }

    IEnumerator AudioOn()
    {
        yield return new WaitForSeconds(5f);
        audioSource.enabled = true;
    }
}
