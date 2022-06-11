using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public TextManager textManager;

    [Header("Text Content")]
    public string locationText;
    [Multiline(10)]
    public string chatText;

    bool m_boxTriggerOn = false;

    private void Awake()
    {        
        chatText = GetComponent<TextBox>().chatText;
        locationText = GetComponent<TextBox>().locationText;
        m_boxTriggerOn = textManager.isTextWorking;
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (m_boxTriggerOn)
        {
            Debug.Log("textBox 작동 중");
            return;
        }
        Debug.Log("textBox touch");
        textManager.chatText.text = chatText.ToString();
        textManager.locationText.text = locationText.ToString();  
        
        if (!m_boxTriggerOn)
        {
            Debug.Log("textBox 작동");
            textManager.OnText();
            textManager.isTextWorking = false;
        }

        //Destroy(this, 10);
    } 
}
