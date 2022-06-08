using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public bool StartNextLevel = false;
    private void OnCollisionEnter(Collision collision)
    {
        StartNextLevel = true;
    }
}
