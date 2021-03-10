using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;



public class BossSceneChange : MonoBehaviour
{
    public GameObject Main;
    public CanvasGroup canvasGroup;

    private void Start()
    {
    }

    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, 2f)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }
    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(0, 2f)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeOutToIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, 2f)
            .OnComplete(() => FadeIn());
    }
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {
            Main.SetActive(false);
            StartCoroutine("WaitForIt");
        }
    }
    IEnumerator WaitForIt()
    {
        FadeOutToIn();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("BossScene");

    }
}
