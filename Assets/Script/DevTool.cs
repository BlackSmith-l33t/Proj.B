using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTool : MonoBehaviour
{
    GameObject directionalLight;

    private void Awake()
    {
        directionalLight = GameObject.Find("Directional Light"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("z"))
        {
            directionalLight.SetActive(false);      
        }
    }
}
