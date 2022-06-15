using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CavePortal : MonoBehaviour
{
    public Image fadeOutImage;
    public GameObject endUI;
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
       
        endUI.SetActive(true);
        Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Finished");
        StartCoroutine(StartFadeOutWhite());
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
          Application.OpenURL(webplayerQuitURL);        
        #else
            Application.Quit();
        #endif
    }
}
