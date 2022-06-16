using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalChapter : MonoBehaviour
{
    public GameObject player;
    public GameObject endUI;
    public Image fadeOutImage;
    public Text locationText;
    public Text chatText;

    // 플레이어 씬 시작 좌표 x : 48.28 / y : 6.5 / x : 295.6

    private void Start()
    {
        StartCoroutine("CheckFall");
    }

    IEnumerator CheckFall()
    {     
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (player.transform.position.y < -100f)
            {
                Color fadeColor = fadeOutImage.color;

                locationText.enabled = false;
                chatText.enabled = false;

                endUI.SetActive(true);
                for (int i = 0; i < 350; i++)
                {
                    float f = i / 100.0f;
                    fadeColor.a = f + 0.5f;
                    fadeOutImage.color = fadeColor;
                    yield return new WaitForSeconds(0.01f);
                }
                
                Quit();
            }
        }
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
