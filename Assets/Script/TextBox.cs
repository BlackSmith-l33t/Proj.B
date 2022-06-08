using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

}
