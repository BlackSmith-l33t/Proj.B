using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
<<<<<<< Updated upstream

public class TextBox : MonoBehaviour
{
    public string text;
    public TextManager textManager;

    Collider collider;
    int playerLayer = 8;

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();       
    }

    private void OnCollisionEnter(Collision other)
    {
        textManager.SetText(text);
    }

=======
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
>>>>>>> Stashed changes
}
