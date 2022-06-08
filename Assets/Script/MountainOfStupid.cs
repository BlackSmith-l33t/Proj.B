using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MountainOfStupid : MonoBehaviour
{
    public event UnityAction OnMountain;
    private void OnCollisionEnter(Collision collision)
    {       
        OnMountain?.Invoke();     
    }
}
