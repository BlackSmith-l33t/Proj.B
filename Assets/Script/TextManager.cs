using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TextManager : MonoBehaviour
{
<<<<<<< Updated upstream
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

=======
    //public static TextManager instance { get; private set; }
   
    public Text   locationText;
    public Text   chatText;
    public Image  fadeOutImage;

    bool isPlaying = false;

    private void Awake()
    {        
        chatText.text = "";
    }
    public void OnText()
    {
        StartCoroutine(ShowText());
>>>>>>> Stashed changes
    }

    IEnumerator ShowText()
    {              
<<<<<<< Updated upstream
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

=======
        if (null ==chatText.text && isPlaying)
        {
            StopAllCoroutines();
        }

        // TODO : Text fade In Out
        //yield return new WaitForSeconds(0.2f);

        //Color fadeColor = fadeOutImage.color;
        Color textColor = new Color(1, 1, 1, 0);
        isPlaying = true;

        //for (int i = 0; i < 200; i++)
        //{
        //    //float f = i / 100.0f;
        //    //fadeColor.a = f + 0.5f;
        //    //fadeOutImage.color = fadeColor;
        //    Debug.Log(textColor.a);
        //    float f = i / 100.0f;
        //    textColor.a = f + 0.5f;       
        //    chatText.color = textColor;
        //    Debug.Log(chatText.color.a);

        //    yield return new WaitForSeconds(0.01f);
        //}

        yield return new WaitForSeconds(6.0f);

        //for (int i = 0; i < 100; i++)
        //{
        //    //float f = i / 100.0f;
        //    //fadeColor.a = f + 0.5f;
        //    //fadeOutImage.color = fadeColor;

        //    float f = i / 100.0f;
        //    textColor.a = f - 0.5f;
        //    locationText.color = textColor;
        //    chatText.color = textColor;

        //    yield return new WaitForSeconds(0.01f);
        //}

        Debug.Log("fade In out");
        chatText.text = null;

        isPlaying = false;
>>>>>>> Stashed changes
        StopAllCoroutines();
    }

    
    




}
