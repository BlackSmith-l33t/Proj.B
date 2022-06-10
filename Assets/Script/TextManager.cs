using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TextManager : MonoBehaviour
{
    //public static TextManager instance { get; private set; }
   
    public Text   locationText;
    public Text   chatText;
    public Image  fadeOutImage;
    public bool isTextWorking = false;

    private void Awake()
    {        
        chatText.text = "";
    }
    public bool OnText()
    {
        StartCoroutine(ShowText());
        return true;
    }

    IEnumerator ShowText()
    {             
        // TODO : Text fade In Out
        //yield return new WaitForSeconds(0.2f);

        //Color fadeColor = fadeOutImage.color;
        //Color textColor = new Color(1, 1, 1, 0);      

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

        yield return new WaitForSeconds(10.0f);

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

        Debug.Log("글자 사라짐");
        chatText.text = null;

        isTextWorking = true;
    }  
}
