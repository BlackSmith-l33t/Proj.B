using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class MountainStart : MonoBehaviour
{ 
     public event UnityAction OnMountainStart;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("MT Enterance");
        OnMountainStart?.Invoke();
    }
}

