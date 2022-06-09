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

    private void Awake()
    {
        chatText = GetComponent<TextBox>().chatText;
        locationText = GetComponent<TextBox>().locationText;   
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("textBox touch");
        textManager.chatText.text = chatText.ToString();
        textManager.locationText.text = locationText.ToString();
        textManager.OnText();
        Destroy(this, 7);
    } 
}
