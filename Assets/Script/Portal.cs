using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public Image fadeOutImage;
    IEnumerator StartFadeOutWhite()
    {
        yield return new WaitForSeconds(0.5f);

        Color fadeColor = fadeOutImage.color;

        for (int i = 0; i < 350; i++)
        {
            float f = i / 100.0f;
            fadeColor.a = f + 0.5f;
            fadeOutImage.color = fadeColor;
            yield return new WaitForSeconds(0.01f);           
        }

        SceneManager.LoadScene("Final Chapter");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Finished");
        StartCoroutine(StartFadeOutWhite());       
    }    
}
