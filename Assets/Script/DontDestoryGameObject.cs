using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryGameObject : MonoBehaviour
{
    public GameObject textBox;

    private void Awake()
    {
        DontDestroyOnLoad(textBox);
    }
}
