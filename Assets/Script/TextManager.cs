using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TextManager : MonoBehaviour
{
    // 싱글톤으로 변경    
    public GameObject        HUD;
    public Text              informationText;
    public Text              ChatText;
    public Image             fadeOutImage;

    string m_chatText = "Abandon all hope, ye who enter here.";
    string m_infoText = "PIT";
   
    private void Awake()
    {
        ChatText.text = m_chatText;
        informationText.text = m_infoText;
    }

    public void SetText(string text)
    {

    }

    IEnumerator ShowText()
    {              
        // TODO : Text fade In Out
        yield return new WaitForSeconds(0.2f);

        Color fadeColor = fadeOutImage.color;

        for (int i = 0; i < 100; i++)
        {
            float f = i / 100.0f;
            fadeColor.a = f + 0.5f;
            fadeOutImage.color = fadeColor;
            yield return new WaitForSeconds(0.01f);
        }

        ChatText.text = null;
        informationText.text = null;

        StopAllCoroutines();
    }

    
    




}
